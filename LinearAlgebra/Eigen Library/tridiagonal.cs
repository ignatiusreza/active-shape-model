
using System;

class tridiagonal
{
    /*************************************************************************
    Reduction of a symmetric matrix which is given by its higher or lower
    triangular part to a tridiagonal matrix using orthogonal similarity
    transformation: Q'*A*Q=T.

    Input parameters:
        A       -   matrix to be transformed
                    array with elements [1..N, 1..N].
        N       -   size of matrix A.
        IsUpper -   storage format. If IsUpper = True, then matrix A is given
                    by its upper triangle, and the lower triangle is not used
                    and not modified by the algorithm, and vice versa
                    if IsUpper = False.

    Output parameters:
        A       -   matrices T and Q in  compact form (see lower)
        D       -   main diagonal of symmetric matrix T.
                    array with elements [1..N].
        D       -   secondary diagonal of symmetric matrix T.
                    array with elements [1..N-1].


      If IsUpper=True, the matrix Q is represented as a product of elementary
      reflectors

         Q = H(n-1) . . . H(2) H(1).

      Each H(i) has the form

         H(i) = I - tau * v * v'

      where tau is a real scalar, and v is a real vector with
      v(i+1:n) = 0 and v(i) = 1; v(1:i-1) is stored on exit in
      A(1:i-1,i+1), and tau in TAU(i).

      If IsUpper=False, the matrix Q is represented as a product of elementary
      reflectors

         Q = H(1) H(2) . . . H(n-1).

      Each H(i) has the form

         H(i) = I - tau * v * v'

      where tau is a real scalar, and v is a real vector with
      v(1:i) = 0 and v(i+1) = 1; v(i+2:n) is stored on exit in A(i+2:n,i),
      and tau in TAU(i).

      The contents of A on exit are illustrated by the following examples
      with n = 5:

      if UPLO = 'U':                       if UPLO = 'L':

        (  d   e   v2  v3  v4 )              (  d                  )
        (      d   e   v3  v4 )              (  e   d              )
        (          d   e   v4 )              (  v1  e   d          )
        (              d   e  )              (  v1  v2  e   d      )
        (                  d  )              (  v1  v2  v3  e   d  )

      where d and e denote diagonal and off-diagonal elements of T, and vi
      denotes an element of the vector defining H(i).

      -- LAPACK routine (version 3.0) --
         Univ. of Tennessee, Univ. of California Berkeley, NAG Ltd.,
         Courant Institute, Argonne National Lab, and Rice University
         October 31, 1992
    *************************************************************************/
    public static void totridiagonal(ref double[,] a,
        int n,
        bool isupper,
        ref double[] tau,
        ref double[] d,
        ref double[] e)
    {
        int i = 0;
        int ip1 = 0;
        int im1 = 0;
        int nmi = 0;
        int nm1 = 0;
        double alpha = 0;
        double taui = 0;
        double v = 0;
        double[] t = new double[0];
        double[] t2 = new double[0];
        double[] t3 = new double[0];
        int i_ = 0;
        int i1_ = 0;

        if( n<=0 )
        {
            return;
        }
        t = new double[n+1];
        t2 = new double[n+1];
        t3 = new double[n+1];
        tau = new double[Math.Max(1, n-1)+1];
        d = new double[n+1];
        e = new double[Math.Max(1, n-1)+1];
        if( isupper )
        {
            
            //
            // Reduce the upper triangle of A
            //
            for(i=n-1; i>=1; i--)
            {
                
                //
                // Generate elementary reflector H(i) = I - tau * v * v'
                // to annihilate A(1:i-1,i+1)
                //
                // DLARFG( I, A( I, I+1 ), A( 1, I+1 ), 1, TAUI );
                //
                ip1 = i+1;
                im1 = i-1;
                if( i>=2 )
                {
                    i1_ = (1) - (2);
                    for(i_=2; i_<=i;i_++)
                    {
                        t[i_] = a[i_+i1_,ip1];
                    }
                }
                t[1] = a[i,ip1];
                reflections.generatereflection(ref t, i, ref taui);
                if( i>=2 )
                {
                    i1_ = (2) - (1);
                    for(i_=1; i_<=im1;i_++)
                    {
                        a[i_,ip1] = t[i_+i1_];
                    }
                }
                a[i,ip1] = t[1];
                e[i] = a[i,i+1];
                if( taui!=0 )
                {
                    
                    //
                    // Apply H(i) from both sides to A(1:i,1:i)
                    //
                    a[i,i+1] = 1;
                    
                    //
                    // Compute  x := tau * A * v  storing x in TAU(1:i)
                    //
                    // DSYMV( UPLO, I, TAUI, A, LDA, A( 1, I+1 ), 1, ZERO, TAU, 1 );
                    //
                    ip1 = i+1;
                    for(i_=1; i_<=i;i_++)
                    {
                        t[i_] = a[i_,ip1];
                    }
                    sblas.symmetricmatrixvectormultiply(ref a, isupper, 1, i, ref t, taui, ref tau);
                    
                    //
                    // Compute  w := x - 1/2 * tau * (x'*v) * v
                    //
                    ip1 = i+1;
                    v = 0.0;
                    for(i_=1; i_<=i;i_++)
                    {
                        v += tau[i_]*a[i_,ip1];
                    }
                    alpha = -(0.5*taui*v);
                    for(i_=1; i_<=i;i_++)
                    {
                        tau[i_] = tau[i_] + alpha*a[i_,ip1];
                    }
                    
                    //
                    // Apply the transformation as a rank-2 update:
                    //    A := A - v * w' - w * v'
                    //
                    // DSYR2( UPLO, I, -ONE, A( 1, I+1 ), 1, TAU, 1, A, LDA );
                    //
                    for(i_=1; i_<=i;i_++)
                    {
                        t[i_] = a[i_,ip1];
                    }
                    sblas.symmetricrank2update(ref a, isupper, 1, i, ref t, ref tau, ref t2, -1);
                    a[i,i+1] = e[i];
                }
                d[i+1] = a[i+1,i+1];
                tau[i] = taui;
            }
            d[1] = a[1,1];
        }
        else
        {
            
            //
            // Reduce the lower triangle of A
            //
            for(i=1; i<=n-1; i++)
            {
                
                //
                // Generate elementary reflector H(i) = I - tau * v * v'
                // to annihilate A(i+2:n,i)
                //
                //DLARFG( N-I, A( I+1, I ), A( MIN( I+2, N ), I ), 1, TAUI );
                //
                nmi = n-i;
                ip1 = i+1;
                i1_ = (ip1) - (1);
                for(i_=1; i_<=nmi;i_++)
                {
                    t[i_] = a[i_+i1_,i];
                }
                reflections.generatereflection(ref t, nmi, ref taui);
                i1_ = (1) - (ip1);
                for(i_=ip1; i_<=n;i_++)
                {
                    a[i_,i] = t[i_+i1_];
                }
                e[i] = a[i+1,i];
                if( taui!=0 )
                {
                    
                    //
                    // Apply H(i) from both sides to A(i+1:n,i+1:n)
                    //
                    a[i+1,i] = 1;
                    
                    //
                    // Compute  x := tau * A * v  storing y in TAU(i:n-1)
                    //
                    //DSYMV( UPLO, N-I, TAUI, A( I+1, I+1 ), LDA, A( I+1, I ), 1, ZERO, TAU( I ), 1 );
                    //
                    ip1 = i+1;
                    nmi = n-i;
                    nm1 = n-1;
                    i1_ = (ip1) - (1);
                    for(i_=1; i_<=nmi;i_++)
                    {
                        t[i_] = a[i_+i1_,i];
                    }
                    sblas.symmetricmatrixvectormultiply(ref a, isupper, i+1, n, ref t, taui, ref t2);
                    i1_ = (1) - (i);
                    for(i_=i; i_<=nm1;i_++)
                    {
                        tau[i_] = t2[i_+i1_];
                    }
                    
                    //
                    // Compute  w := x - 1/2 * tau * (x'*v) * v
                    //
                    nm1 = n-1;
                    ip1 = i+1;
                    i1_ = (ip1)-(i);
                    v = 0.0;
                    for(i_=i; i_<=nm1;i_++)
                    {
                        v += tau[i_]*a[i_+i1_,i];
                    }
                    alpha = -(0.5*taui*v);
                    i1_ = (ip1) - (i);
                    for(i_=i; i_<=nm1;i_++)
                    {
                        tau[i_] = tau[i_] + alpha*a[i_+i1_,i];
                    }
                    
                    //
                    // Apply the transformation as a rank-2 update:
                    //     A := A - v * w' - w * v'
                    //
                    //DSYR2( UPLO, N-I, -ONE, A( I+1, I ), 1, TAU( I ), 1, A( I+1, I+1 ), LDA );
                    //
                    nm1 = n-1;
                    nmi = n-i;
                    ip1 = i+1;
                    i1_ = (ip1) - (1);
                    for(i_=1; i_<=nmi;i_++)
                    {
                        t[i_] = a[i_+i1_,i];
                    }
                    i1_ = (i) - (1);
                    for(i_=1; i_<=nmi;i_++)
                    {
                        t2[i_] = tau[i_+i1_];
                    }
                    sblas.symmetricrank2update(ref a, isupper, i+1, n, ref t, ref t2, ref t3, -1);
                    a[i+1,i] = e[i];
                }
                d[i] = a[i,i];
                tau[i] = taui;
            }
            d[n] = a[n,n];
        }
    }


    /*************************************************************************
    Unpacking matrix Q which reduces symmetric matrix to a tridiagonal
    form.

    Input parameters:
        A       -   the result of a ToTridiagonal subroutine
        N       -   size of matrix A.
        IsUpper -   storage format (a parameter of ToTridiagonal subroutine)
        Tau     -   the result of a ToTridiagonal subroutine

    Output parameters:
        Q       -   transformation matrix.
                    array with elements [1..N, 1..N].

      -- ALGLIB --
         Copyright 2005 by Bochkanov Sergey
    *************************************************************************/
    public static void unpackqfromtridiagonal(ref double[,] a,
        int n,
        bool isupper,
        ref double[] tau,
        ref double[,] q)
    {
        int i = 0;
        int j = 0;
        int ip1 = 0;
        int nmi = 0;
        double[] v = new double[0];
        double[] work = new double[0];
        int i_ = 0;
        int i1_ = 0;

        if( n==0 )
        {
            return;
        }
        
        //
        // init
        //
        q = new double[n+1, n+1];
        v = new double[n+1];
        work = new double[n+1];
        for(i=1; i<=n; i++)
        {
            for(j=1; j<=n; j++)
            {
                if( i==j )
                {
                    q[i,j] = 1;
                }
                else
                {
                    q[i,j] = 0;
                }
            }
        }
        
        //
        // unpack Q
        //
        if( isupper )
        {
            for(i=1; i<=n-1; i++)
            {
                
                //
                // Apply H(i)
                //
                ip1 = i+1;
                for(i_=1; i_<=i;i_++)
                {
                    v[i_] = a[i_,ip1];
                }
                v[i] = 1;
                reflections.applyreflectionfromtheleft(ref q, tau[i], ref v, 1, i, 1, n, ref work);
            }
        }
        else
        {
            for(i=n-1; i>=1; i--)
            {
                
                //
                // Apply H(i)
                //
                ip1 = i+1;
                nmi = n-i;
                i1_ = (ip1) - (1);
                for(i_=1; i_<=nmi;i_++)
                {
                    v[i_] = a[i_+i1_,i];
                }
                v[1] = 1;
                reflections.applyreflectionfromtheleft(ref q, tau[i], ref v, i+1, n, 1, n, ref work);
            }
        }
    }
}
