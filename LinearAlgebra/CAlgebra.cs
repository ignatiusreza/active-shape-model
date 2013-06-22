using System;

namespace LinearAlgebra {
  public class CVector2 {
    double[] _v = new double[2];

    #region "Constructor & Destructor"

    public CVector2(){
      _v[0] = 0;
      _v[1] = 0;
    }

    public CVector2(double a,double b) {
      _v[0] = a;
      _v[1] = b;
    }

    public CVector2(CVector2 v) {
      _v[0] = v[0];
      _v[1] = v[1];
    }

    #endregion

    #region "Properties"

    public double this[int i] {
      get { return _v[i]; }
      set { _v[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add (CVector2 v) {
      _v[0] += v[0];
      _v[1] += v[1];
    }

    public CVector2 addCopy (CVector2 v) {
      return new CVector2(_v[0] + v[0],_v[1] + v[1]);
    }

    public void substract (CVector2 v) {
      _v[0] -= v[0];
      _v[1] -= v[1];
    }

    public CVector2 substractCopy (CVector2 v) {
      return new CVector2(_v[0] - v[0],_v[1] - v[1]);
    }

    public void multiply(double a) {
      _v[0] *= a;
      _v[1] *= a;
    }

    public CVector2 multiplyCopy(double a) {
      return new CVector2(_v[0] * a,_v[1] * a);
    }

    public void divide (double a) {
      _v[0] /= a;
      _v[1] /= a;
    }

    public CVector2 divideCopy(double a) {
      return new CVector2(_v[0] / a,_v[1] / a);
    }

    public void transform (CMatrix3x3 m) {
      double temp = _v[0];
      _v[0] = m[0][0]*temp + m[0][1]*_v[1] + m[0][2];
      _v[1] = m[1][0]*temp + m[1][1]*_v[1] + m[1][2];
    }

    public double length() {
      return Math.Sqrt(length2());
    }

    public double length2() {
      return _v[0]*_v[0] + _v[1]*_v[1];
    }

    public override string ToString() {
      return _v[0] + "," + _v[1];
    }

    #endregion

    #region "Static Methods"

    public static void transform (CMatrix3x3 m,ref double v1,ref double v2) {
      double temp = v1;
      v1 = m[0][0]*temp + m[0][1]*v2 + m[0][2];
      v2 = m[1][0]*temp + m[1][1]*v2 + m[1][2];
    }

    public static double length(double x1,double y1,double x2,double y2) {
      return Math.Sqrt(length2(x1,y1,x2,y2));
    }

    public static double length2(double x1,double y1,double x2,double y2) {
      double vx = x2-x1;
      double vy = y2-y1;
      return vx*vx + vy*vy;
    }

    public static CVector2 vNormal(CVector2 p0, CVector2 p1, CVector2 p2) {
      CVector2 p, q, d;

      d = p1.substractCopy(p0);
      p = new CVector2(d[1],-d[0]);

      d = p2.substractCopy(p1);
      q = new CVector2(d[1],-d[0]);

      p.add(q);
      p.divide(Math.Sqrt(p[0] * p[0] + p[1] * p[1]));
      return p;
    }

    #endregion
  }

  public class CVector3 {
    double[] _v = new double[3];

    #region "Constructor & Destructor"

    public CVector3(){
      _v[0] = 0;
      _v[1] = 0;
      _v[2] = 0;
    }

    public CVector3(double a,double b,double c) {
      _v[0] = a;
      _v[1] = b;
      _v[2] = c;
    }

    public CVector3(CVector3 a) {
      _v[0] = a[0];
      _v[1] = a[1];
      _v[2] = a[2];
    }

    #endregion

    #region "Properties"

    public double this[int i] {
      get { return _v[i]; }
      set { _v[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add(CVector3 a) {
      _v[0] += a[0];
      _v[1] += a[1];
      _v[2] += a[2];
    }

    public CVector3 addCopy(CVector3 a) {
      return new CVector3(_v[0] + a[0],_v[1] + a[1],_v[2] + a[2]);
    }

    public void substract(CVector3 a) {
      _v[0] -= a[0];
      _v[1] -= a[1];
      _v[2] -= a[2];
    }

    public CVector3 substractCopy(CVector3 a) {
      return new CVector3(_v[0] - a[0],_v[1] - a[1],_v[2] - a[2]);
    }

    public void multiply(double a) {
      _v[0] *= a;
      _v[1] *= a;
      _v[2] *= a;
    }
    
    public CVector3 multiplyCopy(double a) {
      return new CVector3(_v[0] * a,_v[1] * a,_v[2] * a);
    }

    public double multiplyDouble(CVector3 a) {
      return (_v[0] * a[0] + _v[1] * a[1] + _v[2] * a[2]);
    }

    public CMatrix3x3 multiplyMatrix(CVector3 a) {
      return new CMatrix3x3(
        new CVector3(_v[0]*a[0],_v[0]*a[1],_v[0]*a[2]),
        new CVector3(_v[1]*a[0],_v[1]*a[1],_v[1]*a[2]),
        new CVector3(_v[2]*a[0],_v[2]*a[1],_v[2]*a[2]));
    }

    public void divide(double a) {
      _v[0] /= a;
      _v[1] /= a;
      _v[2] /= a;
    }

    public CVector3 divideCopy(double a) {
      return new CVector3(_v[0] / a,_v[1] / a,_v[2] / a);
    }

    public override string ToString() {
      return _v[0] + "," + _v[1];
    }

    #endregion
  }

  public class CVector4 {
    double[] _v = new double[4];

    #region "Constructor & Destructor"

    public CVector4(){
      _v[0] = 0;
      _v[1] = 0;
      _v[2] = 0;
      _v[3] = 0;
    }

    public CVector4(double a,double b,double c,double d) {
      _v[0] = a;
      _v[1] = b;
      _v[2] = c;
      _v[3] = d;
    }

    public CVector4(CVector4 a) {
      _v[0] = a[0];
      _v[1] = a[1];
      _v[2] = a[2];
      _v[3] = a[3];
    }

    #endregion

    #region "Properties"

    public double this[int i] {
      get { return _v[i]; }
      set { _v[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add(CVector4 a) {
      _v[0] += a[0];
      _v[1] += a[1];
      _v[2] += a[2];
      _v[3] += a[3];
    }

    public CVector4 addCopy(CVector4 a) {
      return new CVector4(_v[0] + a[0],_v[1] + a[1],_v[2] + a[2],_v[3] + a[3]);
    }

    public void substract(CVector4 a) {
      _v[0] -= a[0];
      _v[1] -= a[1];
      _v[2] -= a[2];
      _v[3] -= a[3];
    }

    public CVector4 substractCopy(CVector4 a) {
      return new CVector4(_v[0] - a[0],_v[1] - a[1],_v[2] - a[2],_v[3] - a[3]);
    }

    public void multiply(double a) {
      _v[0] *= a;
      _v[1] *= a;
      _v[2] *= a;
      _v[3] *= a;
    }
    
    public CVector4 multiplyCopy(double a) {
      return new CVector4(_v[0] * a,_v[1] * a,_v[2] * a,_v[3] * a);
    }

    public double multiplyDouble(CVector4 a) {
      return (_v[0] * a[0] + _v[1] * a[1] + _v[2] * a[2] + _v[3] * a[3]);
    }

    public CMatrix4x4 multiplyMatrix(CVector4 a) {
      return new CMatrix4x4(
        new CVector4(_v[0]*a[0],_v[0]*a[1],_v[0]*a[2],_v[0]*a[3]),
        new CVector4(_v[1]*a[0],_v[1]*a[1],_v[1]*a[2],_v[1]*a[3]),
        new CVector4(_v[2]*a[0],_v[2]*a[1],_v[2]*a[2],_v[2]*a[3]),
        new CVector4(_v[3]*a[0],_v[3]*a[1],_v[3]*a[2],_v[3]*a[3]));
    }

    public void divide(double a) {
      _v[0] /= a;
      _v[1] /= a;
      _v[2] /= a;
      _v[3] /= a;
    }

    public CVector4 divideCopy(double a) {
      return new CVector4(_v[0] / a,_v[1] / a,_v[2] / a,_v[3] / a);
    }

    public override string ToString() {
      return _v[0].ToString("F2") + "," + _v[1].ToString("F2") + "," + _v[2].ToString("F2") + "," + _v[3].ToString("F2");
    }

    #endregion
  }

  public class CVector {
    private int      _size;
    private double[] _v;

    #region "Constructor & Destructor"
    
    public CVector(int numElem) {
      _size = numElem;
      _v    = new double[numElem];
      while((numElem--)!=0)
        _v[numElem] = 0f;
    }

    public CVector(CVector v) {
      _size = v.size;
      _v    = (double[])v._v.Clone();
    }

    public CVector(CXYVector v) {
      _size = 2*v.size;
      _v    = new double[_size]; 
      for(int i=0;i<_size;i+=2) {
        _v[i]   = v[i/2][0];
        _v[i+1] = v[i/2][1];
      }
    }

    #endregion

    #region "Properties"

    public int size {
      get { return _size; }
    }

    public double this[int i] {
      get { return _v[i]; }
      set { _v[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add(CVector a) {
      int n = _size;
      while((n--)!=0)
        _v[n] += a[n];
    }

    public CVector addCopy(CVector a) {
      int     n   = _size;
      CVector ret = new CVector(this);
      while((n--)!=0)
        ret[n] += a[n];

      return ret;
    }

    public void substract(CVector a) {
      int n = _size;
      while((n--)!=0)
        _v[n] -= a[n];
    }

    public CVector substractCopy(CVector a) {
      int     n   = _size;
      CVector ret = new CVector(this);
      while((n--)!=0)
        ret[n] -= a[n];

      return ret;
    }

    public void multiply(double a) {
      int n = _size;
      while((n--)!=0)
        _v[n] *= a;
    }
    
    public CVector multiplyCopy(double a) {
      int     n   = _size;
      CVector ret = new CVector(this);
      while((n--)!=0)
        ret[n] *= a;

      return ret;
    }

    public double multiplyDouble(CVector a) {
      int    n   = _size;
      double ret = 0f;
      while((n--)!=0)
        ret += _v[n] * a[n];

      return ret;
    }

    public CMatrix multiplyMatrix(CVector a) {
      int       n    = a.size;
      CVector []buff = new CVector[n];

      while((n--)!=0) buff[n] = a.multiplyCopy(_v[n]);

      return new CMatrix(buff);
    }

    public void divide(double a) {
      int n = _size;
      while((n--)!=0)
        _v[n] /= a;
    }

    public CVector divideCopy(double a) {
      int     n   = _size;
      CVector ret = new CVector(this);
      while((n--)!=0)
        ret[n] /= a;

      return ret;
    }

    #endregion
  }

  public class CXYVector {
    private int        _size;
    private CVector2[] _v;

    #region "Constructor & Destructor"
   
    public CXYVector(int numElem) {
      _size = numElem;
      _v    = new CVector2[numElem];

      while((numElem--)!=0)
        _v[numElem] = new CVector2();
    }
  
    public CXYVector(int n,CXYVector v) {
      int i;
      _size = n;
      _v    = new CVector2[_size];
      for(i=0;i<_size;i++)
        _v[i] = new CVector2(v[i]);
    }

    public CXYVector(CXYVector v) {
      int i;
      _size = v.size;
      _v    = new CVector2[_size];
      for(i=0;i<_size;i++)
        _v[i] = new CVector2(v[i]);
    }

    #endregion

    #region "Properties"

    public int size {
      get { return _size; }
    }
    
    public CVector2 this[int i] {
      get { return _v[i]; }
      set { _v[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add (CXYVector v) {
      int n = _size;
      while((n--)!=0)
        this[n].add(v[n]);
    }

    public void add(CVector2 v) {
      int n = _size;
      while((n--)!=0)
        this[n].add(v);
    }

    public void substract (CXYVector v) {
      int n = _size;
      while((n--)!=0)
        this[n].substract(v[n]);
    }
    
    public void substract (CVector2 v) {
      int n = _size;
      while((n--)!=0)
        this[n].substract(v);
    }

    public CXYVector substractCopy (CXYVector v) {
      CXYVector ret = new CXYVector(this);
      int n = _size;
      while((n--)!=0)
        ret[n].substract(v[n]);

      return ret;
    }

    public CXYVector substractCopy (CVector2 v) {
      CXYVector ret = new CXYVector(this);
      int n = _size;
      while((n--)!=0)
        ret[n].substract(v);

      return ret;
    }

    public double []substractDouble (CXYVector v) {
      double []ret = new double[_size*2];
      int i;
      for(i=0;i<_size;i++) {
        ret[i*2]   = _v[i][0] - v[i][0];
        ret[i*2+1] = _v[i][1] - v[i][1];
      }

      return ret;
    }

    public void multiply(double a) {
      int n = _size;
      while((n--)!=0)
        this[n].multiply(a);
    }

    public CXYVector multiplyCopy(double a) {
      CXYVector ret = new CXYVector(this);
      int n = _size;
      while((n--)!=0)
        ret[n].multiply(a);

      return ret;
    }

    public void divide (double a) {
      int n = _size;
      while((n--)!=0)
        this[n].divide(a);
    }

    public void transform (CMatrix3x3 m) {
      int n = _size;
      while((n--)!=0)
        this[n].transform(m);
    }

    public double distance(CXYVector target) {
      double res  = 0f;
      int   size = _size;

      while ((size--)!=0) {
        CVector2 temp = _v[size].substractCopy(target[size]);
        res += temp.length2();
      }

      return res;
    }

    public static CMatrix3x3 realign(CXYVector target,CXYVector anchor,double []weight) {
      double X1, Y1, X2, Y2, W, Z, C1, C2;

      int k = anchor.size;

      X1 = Y1 = X2 = Y2 = W = Z = C1 = C2 = 0;

      while ((k--)!=0) {
        double x1 = anchor[k][0];
        double y1 = anchor[k][1];
        double x2 = target[k][0];
        double y2 = target[k][1];

        double w = weight[k];

        W  += w;
        Z  += w * (x2 * x2 + y2 * y2);

        X1 += w * x1; Y1 += w * y1;
        X2 += w * x2; Y2 += w * y2;
        C1 += w * (x1 * x2 + y1 * y2);
        C2 += w * (y1 * x2 - x1 * y2);
      }

      CVector4 solution = 
        new CMatrix4x4(
          new CVector4(X2, -Y2,   W,  0),
          new CVector4(Y2,  X2,   0,  W),
          new CVector4(Z,    0,  X2, Y2),
          new CVector4(0,    Z, -Y2, X2)
        ).inverse().multiplyCopy(new CVector4(X1, Y1, C1, C2));

      CMatrix3x3 trx = new CMatrix3x3(
        new CVector3(solution[0], -solution[1], solution[2]),
        new CVector3(solution[1],  solution[0], solution[3]),
        new CVector3(0, 0, 1));

      target.transform(trx);
      return trx;
    }
    
    #endregion
  }

  public class CMatrix3x3 {
    private CVector3[] _m = new CVector3[3];

    #region "Constructor & Destructor"

    public CMatrix3x3(){
      _m[0] = new CVector3(1,0,0);
      _m[1] = new CVector3(0,1,0);
      _m[2] = new CVector3(0,0,1);
    }

    public CMatrix3x3(CVector3 a,CVector3 b,CVector3 c) {
      _m[0] = new CVector3(a);
      _m[1] = new CVector3(b);
      _m[2] = new CVector3(c);
    }

    public CMatrix3x3(CMatrix3x3 m) {
      _m[0] = new CVector3(m._m[0]);
      _m[1] = new CVector3(m._m[1]);
      _m[2] = new CVector3(m._m[2]);
    }

    #endregion

    #region "Properties"

    public CVector3 this[int i] {
      get { return _m[i]; }
      set { _m[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add(CMatrix3x3 m) {
      _m[0].add(m[0]);
      _m[1].add(m[1]);
      _m[2].add(m[2]);
    }

    public void substract(CMatrix3x3 m) {
      _m[0].substract(m[0]);
      _m[1].substract(m[1]);
      _m[2].substract(m[2]);
    }

    public void multiply(double a) {
      _m[0].multiply(a);
      _m[1].multiply(a);
      _m[2].multiply(a);
    }

    public CVector3 multiplyCopy(CVector3 v) {
      return new CVector3(
        _m[0].multiplyDouble(v),
        _m[1].multiplyDouble(v),
        _m[2].multiplyDouble(v));
    }

    public double []multiplyDouble(double []a) {
      double []res = new double[4];

      res[0] = _m[0][0] * a[0] + _m[0][1] * a[1] + _m[0][2] * a[2];
      res[1] = _m[1][0] * a[0] + _m[1][1] * a[1] + _m[1][2] * a[2];
      res[2] = _m[2][0] * a[0] + _m[2][1] * a[1] + _m[2][2] * a[2];

      return res;
    }

    public void divide(double a) {
      _m[0].divide(a);
      _m[1].divide(a);
      _m[2].divide(a);
    }

    public void swapRow(int i,int j) {
      CVector3 temp = _m[i];
      _m[i] = _m[j];
      _m[j] = temp;
    }

    public CMatrix3x3 inverse() {
      CMatrix3x3 a = new CMatrix3x3(this);
      CMatrix3x3 b = new CMatrix3x3();
      int i, j, i1;
    
      for (j=0; j<3; j++) {
        i1 = j;
        for (i=j+1; i<3; i++)
          if (Math.Abs(a[i][j]) > Math.Abs(a[i1][j]))
            i1 = i;

        a.swapRow(i1,j);
        b.swapRow(i1,j);

        if (a[j][j]==0)
          return null;
        b[j].divide(a[j][j]);
        a[j].divide(a[j][j]);

        for (i=0; i<3; i++)
          if (i!=j) {
            b[i].substract(b[j].multiplyCopy(a[i][j]));
            a[i].substract(a[j].multiplyCopy(a[i][j]));
          }
      }
      return b;
    }

    public void transpose() {
      int    i,j;
      double temp;

      for(i=0;i<3;i++)
        for(j=0;j<i;j++) {
          temp = _m[i][j];
          _m[i][j] = _m[j][i];
          _m[j][i] = temp;
        }
    }

    #endregion
  }
  
  public class CMatrix4x4 {
    private CVector4[] _m = new CVector4[4];

    #region "Constructor & Destructor"

    public CMatrix4x4(){
      _m[0] = new CVector4(1,0,0,0);
      _m[1] = new CVector4(0,1,0,0);
      _m[2] = new CVector4(0,0,1,0);
      _m[3] = new CVector4(0,0,0,1);
    }

    public CMatrix4x4(CVector4 a,CVector4 b,CVector4 c,CVector4 d) {
      _m[0] = new CVector4(a);
      _m[1] = new CVector4(b);
      _m[2] = new CVector4(c);
      _m[3] = new CVector4(d);
    }

    public CMatrix4x4(CMatrix4x4 m) {
      _m[0] = new CVector4(m._m[0]);
      _m[1] = new CVector4(m._m[1]);
      _m[2] = new CVector4(m._m[2]);
      _m[3] = new CVector4(m._m[3]);
    }

    #endregion

    #region "Properties"

    public CVector4 this[int i] {
      get { return _m[i]; }
      set { _m[i] = value; }
    }

    #endregion

    #region "Methods"

    public void add(CMatrix4x4 m) {
      _m[0].add(m[0]);
      _m[1].add(m[1]);
      _m[2].add(m[2]);
      _m[3].add(m[3]);
    }

    public void substract(CMatrix4x4 m) {
      _m[0].substract(m[0]);
      _m[1].substract(m[1]);
      _m[2].substract(m[2]);
      _m[3].substract(m[3]);
    }

    public void multiply(double a) {
      _m[0].multiply(a);
      _m[1].multiply(a);
      _m[2].multiply(a);
      _m[3].multiply(a);
    }

    public CVector4 multiplyCopy(CVector4 v) {
      return new CVector4(
        _m[0].multiplyDouble(v),
        _m[1].multiplyDouble(v),
        _m[2].multiplyDouble(v),
        _m[3].multiplyDouble(v));
    }

    public double []multiplyDouble(double []a) {
      double []res = new double[4];

      res[0] = _m[0][0] * a[0] + _m[0][1] * a[1] + _m[0][2] * a[2] + _m[0][3] * a[3];
      res[1] = _m[1][0] * a[0] + _m[1][1] * a[1] + _m[1][2] * a[2] + _m[1][3] * a[3];
      res[2] = _m[2][0] * a[0] + _m[2][1] * a[1] + _m[2][2] * a[2] + _m[2][3] * a[3];
      res[3] = _m[3][0] * a[0] + _m[3][1] * a[1] + _m[3][2] * a[2] + _m[3][3] * a[3];

      return res;
    }

    public void divide(double a) {
      _m[0].divide(a);
      _m[1].divide(a);
      _m[2].divide(a);
      _m[3].divide(a);
    }

    public void swapRow(int i,int j) {
      CVector4 temp = _m[i];
      _m[i] = _m[j];
      _m[j] = temp;
    }
    
    public CMatrix4x4 inverse() {
      CMatrix4x4 a = new CMatrix4x4(this);
      CMatrix4x4 b = new CMatrix4x4();
      int i, j, i1;
    
      for (j=0; j<4; j++) {
        i1 = j;
        for (i=j+1; i<4; i++)
          if (Math.Abs(a[i][j]) > Math.Abs(a[i1][j]))
            i1 = i;

        a.swapRow(i1,j);
        b.swapRow(i1,j);

        if (a[j][j]==0)
          return null;
        b[j].divide(a[j][j]);
        a[j].divide(a[j][j]);

        for (i=0; i<4; i++)
          if (i!=j) {
            b[i].substract(b[j].multiplyCopy(a[i][j]));
            a[i].substract(a[j].multiplyCopy(a[i][j]));
          }
      }
      return b;
    }

    public void transpose() {
      int    i,j;
      double temp;

      for(i=0;i<4;i++)
        for(j=0;j<i;j++) {
          temp = _m[i][j];
          _m[i][j] = _m[j][i];
          _m[j][i] = temp;
        }
    }

    public override string ToString() {
      string ret;
      ret  = _m[0] + "\n";
      ret += _m[1] + "\n";
      ret += _m[2] + "\n";
      ret += _m[3] + "\n";
      return ret;
    }

    #endregion
  }

  public class CMatrix {
    private int       _size;
    private CVector[] _m;

    #region "Constructor & Destructor"

    public CMatrix(int size,bool isIdentity){
      int i;
      _size = size;

      _m = new CVector[size];
      for(i=0;i<size;i++) {
        _m[i] = new CVector(size);
        if(isIdentity)
          _m[i][i] = 1;
      }
    }

    public CMatrix(CVector []v) {
      _size = v[0].size;
      _m = new CVector[_size];
      for(int i = 0;i<_size;i++)
        _m[i] = new CVector(v[i]);
    }

    public CMatrix(CMatrix m) {
      _size = m.size;
      _m = new CVector[_size];
      for(int i = 0;i<_size;i++)
        _m[i] = new CVector(m._m[i]);
    }

    public CMatrix(double [,]a,int size) {
      int i,j;
      _size = size;
      _m = new CVector[size];
      for(i=0;i<size;i++) {
        _m[i] = new CVector(size);
        for(j=0;j<size;j++)
          _m[i][j] = a[i,j];
      }
    }

    #endregion

    #region "Properties"

    public int size {
      get { return _size; }
    }

    public CVector this[int i] {
      get { return _m[i]; }
    }

    public double this[int i,int j] {
      get { return _m[i][j]; }
    }

    #endregion

    #region "Methods"

    public void add(CMatrix m) {
      int n = _size;
      while((n--)!=0) _m[n].add(m[n]);
    }

    public void substract(CMatrix m) {
      int n = _size;
      while((n--)!=0) _m[n].substract(m[n]);
    }

    public void multiply(double a) {
      int n = _size;
      while((n--)!=0) _m[n].multiply(a);
    }

    public double []multiplyDouble(double []a) {
      int i,j;
      double []res = new double[_size];

      for(i=0;i<_size;i++) {
        res[i] = 0.0;
        for(j=0;j<_size;j++)
          res[i] += _m[i][j] * a[j];
      }

      return res;
    }

    public void divide(double a) {
      int n = _size;
      while((n--)!=0) _m[n].divide(a);
    }

    public void swapRow(int i,int j) {
      CVector temp = _m[i];
      _m[i] = _m[j];
      _m[j] = temp;
    }
    
    public CMatrix inverse() {
      CMatrix a = new CMatrix(this);
      CMatrix b = new CMatrix(_size,false);
      int i, j, i1;
    
      for (j=0; j<_size; j++) {
        i1 = j;
        for (i=j+1; i<_size; i++)
          if (Math.Abs(a[i][j]) > Math.Abs(a[i1][j]))
            i1 = i;

        a.swapRow(i1,j);
        b.swapRow(i1,j);

        if (a[j][j]==0)
          return null;
        b[j].divide(a[j][j]);
        a[j].divide(a[j][j]);

        for (i=0; i<_size; i++)
          if (i!=j) {
            b[i].substract(b[j].multiplyCopy(a[i][j]));
            a[i].substract(a[j].multiplyCopy(a[i][j]));
          }
      }
      return b;
    }

    public void transpose() {
      int    i,j;
      double temp;

      for(i=0;i<size;i++)
        for(j=0;j<i;j++) {
          temp = _m[i][j];
          _m[i][j] = _m[j][i];
          _m[j][i] = temp;
        }
    }

    #endregion
  }
}
