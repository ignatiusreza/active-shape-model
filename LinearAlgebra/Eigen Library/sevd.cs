
using System;

class sevd
{
    /*************************************************************************
    Finding the eigenvalues and eigenvectors of a symmetric matrix

    The algorithm finds eigen pairs of a symmetric matrix by reducing it to
    tridiagonal form and using the QL/QR algorithm.

    Input parameters:
        A       -   symmetric matrix which is given by its upper or lower
                    triangular part.
                    Array whose indexes range within [1..N, 1..N].
        N       -   size of matrix A.
        IsUpper -   storage format.
        ZNeeded -   flag controlling whether the eigenvectors are needed or not.
                    If ZNeeded is equal to:
                     * 0, the eigenvectors are not returned;
                     * 1, the eigenvectors are returned.

    Output parameters:
        D       -   eigenvalues in ascending order.
                    Array whose index ranges within [1..N].
        Z       -   if ZNeeded is equal to:
                     * 0, Z hasn’t changed;
                     * 1, Z contains the eigenvectors.
                    Array whose indexes range within [1..N, 1..N].
                    The eigenvectors are stored in the matrix columns.

    Result:
        True, if the algorithm has converged.
        False, if the algorithm hasn't converged (uncommon case).

      -- ALGLIB --
         Copyright 2005 by Bochkanov Sergey
    *************************************************************************/
    public static bool symmetricevd(double[,] a,
        int n,
        int zneeded,
        bool isupper,
        ref double[] d,
        ref double[,] z)
    {
        bool result = new bool();
        double[] tau = new double[0];
        double[] e = new double[0];

        a = (double[,])a.Clone();

        System.Diagnostics.Debug.Assert(zneeded==0 | zneeded==1, "SymmetricEVD: incorrect ZNeeded");
        tridiagonal.totridiagonal(ref a, n, isupper, ref tau, ref d, ref e);
        if( zneeded==1 )
        {
            tridiagonal.unpackqfromtridiagonal(ref a, n, isupper, ref tau, ref z);
        }
        result = tdevd.tridiagonalevd(ref d, e, n, zneeded, ref z);
        return result;
    }
}
