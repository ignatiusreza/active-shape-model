using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace LinearAlgebra {
	[Serializable]
	public class CEigen {
		#region	 "Atrribute"
		
		private int       _n;
		private double[,] _vectors;
		private double[]  _values;
		
		#endregion

    #region "Constructor & Destructor"

    public CEigen(int n,double [,]vectors,double []values) {
      _n = n;
      _vectors = (double [,])vectors.Clone();
      _values  = (double [])values;
    }

    #endregion

    #region "Properties"

    public int size {
      get { return _n;}
    }

    public double[,] vectors {
      get { return _vectors; }
    }

    public double[] values {
      get { return _values; }
    }

    #endregion

    #region "Methods"

    public static CEigen calculate(CMatrix covarian) {
      int        n    = covarian.size+1;
      double  [,]buff = new double[n,n];
      double  [,]z    = new double[n,n];
      double   []d    = new double[n];
      int      []flag = new int[n];

      int i,j;
      for(i=1;i<n;i++)
        for(j=1;j<n;j++)
          buff[i,j] = covarian[i-1][j-1];
      n--;

      sevd.symmetricevd(buff,n,1,true,ref d,ref z);

      for(i=0;i<n;i++) {
        d[i]    = d[i+1];
        flag[i] = i;
      }
      d[i] = 0.0;

      // urutin dulu d dan z
      Array.Sort(d,flag,new CEigenComparer());

      for(i=0;i<n;i++)
        for(j=0;j<n;j++)
          buff[i,j] = z[i+1,flag[j]+1];

      return new CEigen(n,buff,d);
    }
		
		#endregion
  }

  public class CEigenComparer : IComparer {
    int IComparer.Compare( Object x, Object y )  {
      double _delta = Math.Abs((double)y) - Math.Abs((double)x);
      if(_delta > 10e-100) return 1;
      if(_delta < -10e-100) return -1;
      return 0;
    }
  }
}