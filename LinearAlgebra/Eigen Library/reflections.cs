
using System;

class reflections
{
    /*************************************************************************
    Generation of an elementary reflection transformation

    The subroutine generates elementary reflection H of order N, so that, for
    a given X, the following equality holds true:

        ( X(1) )   ( Beta )
    H * (  ..  ) = (  0   )
        ( X(n) )   (  0   )

    where
                  ( V(1) )
    H = 1 - Tau * (  ..  ) * ( V(1), ..., V(n) )
                  ( V(n) )

    where the first component of vector V equals 1.

    Input parameters:
        X   -   vector. Array whose index ranges within [1..N].
        N   -   reflection order.

    Output parameters:
        X   -   components from 2 to N are replaced with vector V.
                The first component is replaced with parameter Beta.
        Tau -   scalar value Tau. If X is a null vector, Tau equals 0,
                otherwise 1 <= Tau <= 2.

    This subroutine is the modification of the DLARFG subroutines from
    the LAPACK library. It has a similar functionality except for the
    fact that it doesn’t handle errors when the intermediate results
    cause an overflow.


    MODIFICATIONS:
        24.12.2005 sign(Alpha) was replaced with an analogous to the Fortran SIGN code.

      -- LAPACK auxiliary routine (version 3.0) --
         Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
         Courant Institute, Argonne National Lab, and Rice University
         September 30, 1994
    *************************************************************************/
    public static void generatereflection(ref double[] x,
        int n,
        ref double tau)
    {
        int j = 0;
        double alpha = 0;
        double xnorm = 0;
        double v = 0;
        double beta = 0;
        double mx = 0;
        int i_ = 0;

        
        //
        // Executable Statements ..
        //
        if( n<=1 )
        {
            tau = 0;
            return;
        }
        
        //
        // XNORM = DNRM2( N-1, X, INCX )
        //
        alpha = x[1];
        mx = 0;
        for(j=2; j<=n; j++)
        {
            mx = Math.Max(Math.Abs(x[j]), mx);
        }
        xnorm = 0;
        if( mx!=0 )
        {
            for(j=2; j<=n; j++)
            {
                xnorm = xnorm+AP.Math.Sqr(x[j]/mx);
            }
            xnorm = Math.Sqrt(xnorm)*mx;
        }
        if( xnorm==0 )
        {
            
            //
            // H  =  I
            //
            tau = 0;
            return;
        }
        
        //
        // general case
        //
        mx = Math.Max(Math.Abs(alpha), Math.Abs(xnorm));
        beta = -(mx*Math.Sqrt(AP.Math.Sqr(alpha/mx)+AP.Math.Sqr(xnorm/mx)));
        if( alpha<0 )
        {
            beta = -beta;
        }
        tau = (beta-alpha)/beta;
        v = 1/(alpha-beta);
        for(i_=2; i_<=n;i_++)
        {
            x[i_] = v*x[i_];
        }
        x[1] = beta;
    }


    /*************************************************************************
    Application of an elementary reflection to a rectangular matrix of size MxN

    The algorithm pre-multiplies the matrix by an elementary reflection transformation
    which is given by column V and scalar Tau (see the description of the
    GenerateReflection procedure). Not the whole matrix but only a part of it
    is transformed (rows from M1 to M2, columns from N1 to N2). Only the elements
    of this submatrix are changed.

    Input parameters:
        C       -   matrix to be transformed.
        Tau     -   scalar defining the transformation.
        V       -   column defining the transformation.
                    Array whose index ranges within [1..M2-M1+1].
        M1, M2  -   range of rows to be transformed.
        N1, N2  -   range of columns to be transformed.
        WORK    -   working array whose indexes goes from N1 to N2.

    Output parameters:
        C       -   the result of multiplying the input matrix C by the
                    transformation matrix which is given by Tau and V.
                    If N1>N2 or M1>M2, C is not modified.

      -- LAPACK auxiliary routine (version 3.0) --
         Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
         Courant Institute, Argonne National Lab, and Rice University
         September 30, 1994
    *************************************************************************/
    public static void applyreflectionfromtheleft(ref double[,] c,
        double tau,
        ref double[] v,
        int m1,
        int m2,
        int n1,
        int n2,
        ref double[] work)
    {
        double t = 0;
        int i = 0;
        int vm = 0;
        int i_ = 0;

        if( tau==0 | n1>n2 | m1>m2 )
        {
            return;
        }
        
        //
        // w := C' * v
        //
        vm = m2-m1+1;
        for(i=n1; i<=n2; i++)
        {
            work[i] = 0;
        }
        for(i=m1; i<=m2; i++)
        {
            t = v[i+1-m1];
            for(i_=n1; i_<=n2;i_++)
            {
                work[i_] = work[i_] + t*c[i,i_];
            }
        }
        
        //
        // C := C - tau * v * w'
        //
        for(i=m1; i<=m2; i++)
        {
            t = v[i-m1+1]*tau;
            for(i_=n1; i_<=n2;i_++)
            {
                c[i,i_] = c[i,i_] - t*work[i_];
            }
        }
    }


    /*************************************************************************
    Application of an elementary reflection to a rectangular matrix of size MxN

    The algorithm post-multiplies the matrix by an elementary reflection transformation
    which is given by column V and scalar Tau (see the description of the
    GenerateReflection procedure). Not the whole matrix but only a part of it
    is transformed (rows from M1 to M2, columns from N1 to N2). Only the
    elements of this submatrix are changed.

    Input parameters:
        C       -   matrix to be transformed.
        Tau     -   scalar defining the transformation.
        V       -   column defining the transformation.
                    Array whose index ranges within [1..N2-N1+1].
        M1, M2  -   range of rows to be transformed.
        N1, N2  -   range of columns to be transformed.
        WORK    -   working array whose indexes goes from M1 to M2.

    Output parameters:
        C       -   the result of multiplying the input matrix C by the
                    transformation matrix which is given by Tau and V.
                    If N1>N2 or M1>M2, C is not modified.

      -- LAPACK auxiliary routine (version 3.0) --
         Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
         Courant Institute, Argonne National Lab, and Rice University
         September 30, 1994
    *************************************************************************/
    public static void applyreflectionfromtheright(ref double[,] c,
        double tau,
        ref double[] v,
        int m1,
        int m2,
        int n1,
        int n2,
        ref double[] work)
    {
        double t = 0;
        int i = 0;
        int vm = 0;
        int i_ = 0;
        int i1_ = 0;

        if( tau==0 | n1>n2 | m1>m2 )
        {
            return;
        }
        
        //
        // w := C * v
        //
        vm = n2-n1+1;
        for(i=m1; i<=m2; i++)
        {
            i1_ = (1)-(n1);
            t = 0.0;
            for(i_=n1; i_<=n2;i_++)
            {
                t += c[i,i_]*v[i_+i1_];
            }
            work[i] = t;
        }
        
        //
        // C := C - w * v'
        //
        for(i=m1; i<=m2; i++)
        {
            t = work[i]*tau;
            i1_ = (1) - (n1);
            for(i_=n1; i_<=n2;i_++)
            {
                c[i,i_] = c[i,i_] - t*v[i_+i1_];
            }
        }
    }
}
