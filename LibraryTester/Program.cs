using System;
using System.Collections.Generic;
using System.Text;

using ASMLibrary;
using LinearAlgebra;

namespace LibraryTester {
  class Program {
    static void Main(string[] args) {
      CMatrix4x4 temp = new CMatrix4x4(
        new CVector4(10,5,3,7),
        new CVector4(-2,7,-10,1),
        new CVector4(0,3,1,6),
        new CVector4(2,-3,0,-1));

      CMatrix4x4 inv = temp.inverse();

      CMatrix buff = new CMatrix(3,false);

      buff[0][0] = 8.0/9;buff[0][1] = 1.0/2;buff[0][2] = 1.0/3;
      buff[1][0] = 1.0/2;buff[1][1] = 1.0/3;buff[1][2] = 1.0/4;
      buff[2][0] = 1.0/3;buff[2][1] = 1.0/4;buff[2][2] = 1.0/5;

      CEigen res = CEigen.calculate(buff);

      System.Console.WriteLine("T");
      for(int i=0;i<3;i++) {
        for(int j=0;j<3;j++)
          System.Console.Write(res.vectors[i,j] + " ");
        System.Console.WriteLine();
      }

      System.Console.WriteLine("d");
      for(int i=0;i<3;i++)
        System.Console.WriteLine(res.values[i]);

      CVector dx = new CVector(10);
      dx[0] = 3.369;
      dx[1] = 9.999;
      dx[2] = 12;
      dx[3] = 0.00458;
      dx[4] = 398;
      dx[5] = 0.0782;
      dx[6] = 1.596;
      dx[7] = 4.2118;
      dx[8] = 6.2258;
      dx[9] = 0.0795;

      CMatrix ret = dx.multiplyMatrix(dx);
      System.Console.WriteLine("dxdxT");
      for(int i=0;i<10;i++) {
        for(int j=0;j<10;j++)
          System.Console.Write(ret[i,j] + " ");
        System.Console.WriteLine();
      }

      System.Console.In.ReadToEnd();
    }
  }
}