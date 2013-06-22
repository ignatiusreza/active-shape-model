using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

using LinearAlgebra;
using AForge.Imaging.Filters;

namespace ASMLibrary {
  public class CSample {
    #region "Attributes"

    private string    _pictureFilename;
    private int       _numPoints;
    private CXYVector _points;

    #endregion
    
    #region "Constructor & Destructor"
    
    public CSample(string newImageFilename) {
      _pictureFilename = newImageFilename;
      _numPoints       = 0;
      _points          = new CXYVector(CSettings.MAXPOINT);
    }

    #endregion
    
    #region "Properties"

    public CVector2 this[int i] {
      get { return _points[i]; }
    }

    public string pictureFilename {
      get { return _pictureFilename;  }
      set { _pictureFilename = value; }
    }

    public CXYVector points {
      get { return _points; }
    }

    #endregion
    
    #region "Methods"
    
    public void addPoint(CVector2 newPoint) {
      addPoint(newPoint[0],newPoint[1]);
    }

    public void addPoint(double X,double Y) {
      _points[_numPoints][0] = X;
      _points[_numPoints++][1] = Y;
    }

    public void removePoint(int idx) {
      int i;
      _numPoints--;
      for(i = idx;i < _numPoints;i++) {
        _points[i][0] = _points[i+1][0];
        _points[i][1] = _points[i+1][1];
      }
      _points[i][0] = 0;
      _points[i][1] = 0;
    }
  
    #endregion
  }

  public class CTrainingSet {
    #region "Attributes"
    
    private string _name;
    private string _path;
    private Size   _clippingSize;

    private int       _numSamples;
    private int       _numPoints;
    private ArrayList _sample;
    private bool[,]   _connectivity;
    private bool[]    _isSelected;
    private double    _energy;

    private Image _activeSampleImage;
    private int   _activeSampleIdx = -1;

    private CXYVector[] _trainingData;
    private CXYVector   _mean,_newMean,_normalShape;
    private double[]    _weight;

    #endregion

    #region "Constructor & Destructor"

    public CTrainingSet () {
      _numSamples   = 0;
      _numPoints    = 0;
      _sample       = new ArrayList();
      _connectivity = new bool[CSettings.MAXPOINT,CSettings.MAXPOINT];
      _isSelected   = new bool[CSettings.MAXPOINT];
      _energy       = 0;
    }

    public void Dispose() {
      if(_activeSampleImage != null) {
        _activeSampleImage.Dispose();
        _activeSampleImage = null;
      }
      _sample.Clear();
      _sample       = null;
      _connectivity = null;
      _isSelected   = null;
    }

    #endregion
    
    #region "Properties"

    public string name {
      get { return this._name; }
      set { this._name = value; }
    }
    
    public string path {
      get { return this._path; }
      set { this._path = value; }
    }

    public Size clippingSize {
      get { return this._clippingSize; }
      set { this._clippingSize = value; }
    }

    public int numSamples {
      get { return this._numSamples; }
      set { this._numSamples = value; }
    }
     
    public int numPoints {
      get { return _numPoints; }
    }

    public ArrayList sample {
      get { return _sample; }
    }

    public bool[] isSelected {
      get { return _isSelected; }
    }

    public double energy {
      get { return _energy; }
    }
    
    public CSample activeSample {
      get { 
        if(_activeSampleIdx == -1) return null;
        return (CSample)_sample[_activeSampleIdx];
      }
    }

    public int activeSampleIdx {
      get { return this._activeSampleIdx; }
      set { 
        if(_activeSampleImage != null) {
          _activeSampleImage.Dispose();
          _activeSampleImage = null;
        }
        if(value != -1)
          _activeSampleImage = Image.FromFile(((CSample)_sample[value]).pictureFilename);

        this._activeSampleIdx = value;
      }
    }

    public Image activeSampleImage {
      get { return _activeSampleImage; }
    }

    public CXYVector[] trainingData {
      get { return _trainingData; }
    }

    public CXYVector mean {
      get { return _mean; }
    }

    #endregion

    #region "Methods"

    public void addSample(Image newSample) {
      int i;
      if(!Directory.Exists(CSettings.CACHEDIR))
        Directory.CreateDirectory(CSettings.CACHEDIR);
      string newFilename  = CSettings.CACHEDIR + CSettings.FILENAMECOUNTER.ToString().PadLeft(4,'0') + ".jpg";
      _sample.Add(new CSample(newFilename));
      newSample.Save(newFilename);
      
      if(_numSamples > 0)
        for(i=0;i<_numPoints;i++)
         ((CSample)_sample[_numSamples]).addPoint(((CSample)_sample[_numSamples-1])[i]);

      _numSamples++;
      CSettings.FILENAMECOUNTER++;
    }

    public void removeSample(int idx) {
      _sample.RemoveAt(idx);
      _numSamples--;
      if(_numSamples == 0) _numPoints = 0;
    }

    public int isPointExist(double X,double Y) {
      int i;
      for(i=0;i<_numPoints;i++) {
        double x = ((CSample)_sample[_activeSampleIdx])[i][0] - X;
        double y = ((CSample)_sample[_activeSampleIdx])[i][1] - Y;
        if((x*x + y*y) <= 10e-4)
          return i;
      }
      return -1;
    }

    public int addPoint(CVector2 newPoint) {
      return addPoint(newPoint[0],newPoint[1]);
    }

    public int addPoint(double X,double Y) {
      if(_numPoints >= CSettings.MAXPOINT)
        return -1;

      // Add Point In All Samples
      int i;
      for(i=0;i<_numSamples;i++)
        ((CSample)_sample[i]).addPoint(X,Y);
      
      return _numPoints++;
    }

    public bool removePoint(int idx) {
      if(_numPoints >= CSettings.MAXPOINT)
        return false;

      // Remove Point In All Samples
      int i,j;
      for(i=0;i<_numSamples;i++)
        ((CSample)_sample[i]).removePoint(idx);

      // Update Connectivity Matrix
      for(i=0;i<_numPoints;i++)
        _connectivity[i,idx] = _connectivity[idx,i] = false;
      for(i=idx+1;i<_numPoints;i++) {
        for(j=0;j<idx-1;j++) {
          _connectivity[i-1,j] = _connectivity[i,j];
          _connectivity[j,i-1] = _connectivity[j,i];
        }
        for(j=idx+1;j<_numPoints;j++)
          _connectivity[i-1,j-1] = _connectivity[i,j];
      }
      for(i=0;i<_numPoints;i++)
        _connectivity[i,_numPoints-1] = _connectivity[_numPoints-1,i] = false;

      // Update selection
      for(i=idx+1;i<_numPoints;i++)
        _isSelected[i-1] = _isSelected[i];

      _numPoints--;

      return true;
    }

    public void moveSelectedPoint(double x,double y) {
      int i;
      CVector2 buff = new CVector2(x,y);
      if(_activeSampleIdx == -1) return;
      for(i=0;i<_numPoints;i++)
        if(_isSelected[i])
          activeSample[i].add(buff);
    }

    public bool connect(int i,int j,bool isConnect) {
      if(i < 0 || i > _numPoints || j < 0 || j > _numPoints)
        return false;

      _connectivity[i,j] = _connectivity[j,i] = isConnect;
      return true;
    }

    public bool isConnected(int i,int j) {
      if(i < 0 || i > _numPoints || j < 0 || j > _numPoints)
        return false;
      return _connectivity[i,j];
    }

    private void disconnectAll() {
      int i,j;

      for(i=0;i<_numPoints;i++)
        for(j=0;j<_numPoints;j++)
          _connectivity[i,j] = false;
    }

    public bool select(int i, bool isSelect) {
      if(i < 0 || i > _numPoints)
        return false;
      _isSelected[i] = isSelect;
      return true;
    }

    public void selectAllInArea(double X1, double Y1, double X2, double Y2) {
      int i;

      for(i=0;i<_numPoints;i++) {
        double x = activeSample[i][0],y = activeSample[i][1];
        if((x-X1) >= 10e-6 && (X2-x) >= 10e-6 &&
           (y-Y1) >= 10e-6 && (Y2-y) >= 10e-6)
          _isSelected[i] = true;
      }
    }

    public void connectAllSelected(bool isConnect) {
      int i,j;

      for(i=0;i<_numPoints;i++)
        if(_isSelected[i])
          for(j=0;j<i;j++)
            if(_isSelected[j])
              connect(i,j,isConnect);
    }

    public void removeAllSelected() {
      int i;

      for(i=0;i<_numPoints;i++)
        if(_isSelected[i])
           removePoint(i--);
    }

    public void getSelectedBoundingRect(out double X1,out double Y1,out double X2,out double Y2) {
      int i;
      X1 = Y1 = 20000;
      X2 = Y2 = -1;
      if(_activeSampleIdx == -1) return;
      for(i=0;i<_numPoints;i++)
        if(_isSelected[i]) {
          if((activeSample[i][0]-X1) <= 10e-6) X1 = activeSample[i][0];
          if((X2-activeSample[i][0]) <= 10e-6) X2 = activeSample[i][0];
          if((activeSample[i][1]-Y1) <= 10e-6) Y1 = activeSample[i][1];
          if((Y2-activeSample[i][1]) <= 10e-6) Y2 = activeSample[i][1];
        }
    }

    public void diselectAll() {
      int i;

      for(i=0;i<_numPoints;i++)
        _isSelected[i] = false;
    }

    #endregion

    #region "File I/O"

    public void createNew(string path,string name,Size clippingSize) {
      // Initialize Attribute
      _path = path;
      _name = name;
      _clippingSize = clippingSize;
      _numSamples = 0;
      _activeSampleIdx = -1;
      _numPoints = 0;
      _sample.Clear();
      disconnectAll();      

      // Create Training Set Project & Sample Directory
      Directory.CreateDirectory(path + name + "_data");
      StreamWriter tsFile = File.CreateText(path + name + ".ts");
      tsFile.WriteLine("# Training Set Project File");
      tsFile.WriteLine("# This File Is Automaticaly Generated");
      tsFile.WriteLine("# Do Not Manualy Modify The Content Of This File\n");
      tsFile.WriteLine("clippingSize " + _clippingSize.Width + " " + _clippingSize.Height);
      tsFile.WriteLine("# Number Of Sample");
      tsFile.WriteLine("0\n");
      tsFile.WriteLine("# Number Of Points");
      tsFile.WriteLine("0\n");
      tsFile.WriteLine("# Connectivity Data");
      tsFile.Close();

      CSettings.FILENAMECOUNTER = 0;
    }

    public bool open(string path,string name) {
      if(!File.Exists(path + name)) return false;
      CSettings.status.Text = "Opening Training Set";
      CSettings.status.Show();
      
      try
      {
        _path = path;
        _name = Path.GetFileNameWithoutExtension(name);
        // read main .ts file
        StreamReader tsFile = File.OpenText(_path + _name + ".ts");
        bool isStart = false;
        int ctr = 1,j;

        CSettings.status.Text = "Opening Training Set : " + _name;
        CSettings.status.statusLabel.Text = "Opening " + _name + ".ts";
        CSettings.status.Refresh();

        while(!tsFile.EndOfStream) {
          string curLine = tsFile.ReadLine().Trim();
          if(curLine == "" || curLine[0] == '#') continue;
          string[] word = curLine.Split(' ');

          if(isStart) {
            if(word[0] == "_EndConnectivity") {
              isStart = false;
              continue;
            }
            for(j=0;j<word.Length;j++)
              if(word[j]=="1")
                _connectivity[ctr,j] = _connectivity[j,ctr] = true;
            ctr++;
          }else{
            switch(word[0]) {
              case "clippingSize" :
                _clippingSize = new Size(int.Parse(word[1]),int.Parse(word[2]));
                break;
              case "numsample" :
                _numSamples = int.Parse(word[1]);
                break;
              case "numpoint" :
                _numPoints  = int.Parse(word[1]);
                break;
              case "_StartConnectivity" :
                isStart = true;
                disconnectAll();
                break;
            }
          }
        }
        tsFile.Close();
        tsFile.Dispose();
        tsFile = null;

        string cacheFolder = CSettings.CACHEDIR;
        if(Directory.Exists(cacheFolder)) Directory.Delete(cacheFolder,true);
        Directory.CreateDirectory(cacheFolder);

        int i;

        CSettings.status.statusProgress.Minimum = 0;
        CSettings.status.statusProgress.Maximum = _numSamples;
        CSettings.status.statusProgress.Step    = 1;
        CSettings.status.statusProgress.Value   = 0;
        CSettings.status.statusProgress.Visible = true;
        
        for(i=0;i<_numSamples;i++) {
          string dataNumber = i.ToString().PadLeft(4,'0');
          string imageFilenameSrc = _path + _name + "_data\\" + _name + "_" + dataNumber + ".jpg";
          string imageFilenameDes = cacheFolder + dataNumber + ".jpg";
          string textFilename  = _path + _name + "_data\\" + _name + "_" + dataNumber + ".txt";

          CSettings.status.statusLabel.Text = "Opening sample data " + dataNumber + "/" + _numSamples;
          CSettings.status.statusLabel.Refresh();
          CSettings.status.statusProgress.PerformStep();
          CSettings.status.statusProgress.Invalidate();

          // Copy original data to a temp folder
          File.Copy(imageFilenameSrc,imageFilenameDes);
          _sample.Add(new CSample(imageFilenameDes));

          // read *_points.txt file          
          tsFile = File.OpenText(textFilename);
          isStart = false;
          ctr = 0;
          while(!tsFile.EndOfStream) {
            string curLine = tsFile.ReadLine().Trim();
            if(curLine == "" || curLine[0] == '#') continue;
            string[] word = curLine.Split(' ');

            if(isStart) {
              if(word[0] == "_EndPoint") {
                if(_numPoints != ctr) return false;
                isStart = false;
                continue;
              }
              ((CSample)_sample[i]).addPoint(double.Parse(word[0]),double.Parse(word[1]));
              ctr++;
            }else{
              if(word[0] == "_StartPoint") 
                  isStart = true;
            }
          }
          tsFile.Close();
          tsFile.Dispose();
        }
      }catch(Exception) {
        CSettings.status.Hide();

        return false;
      }

      CSettings.status.Hide();
      CSettings.FILENAMECOUNTER = _numSamples;

      return true;
    }

    public void saveToDisk() { saveToDisk("",""); }

    public void saveToDisk(string path,string name) {
      CSettings.status.Text = "Saving Training Set";
      CSettings.status.Show();

      if(path == "") path = _path;
      if(name == "") name = _name;
      else name = Path.GetFileNameWithoutExtension(name);

      // Save Main Training Set File
      int i,j;
      StreamWriter tsFile = null;
      if(File.Exists(path + name + ".ts"))
        File.Delete(path + name + ".ts");
        
      CSettings.status.statusLabel.Text = "Saving " + _name + ".ts";
      CSettings.status.statusLabel.Refresh();

      tsFile = File.CreateText(path + name + ".ts");
      tsFile.WriteLine("# Training Set Project File");
      tsFile.WriteLine("# This File Is Automaticaly Generated");
      tsFile.WriteLine("# Do Not Manualy Modify The Content Of This File\n");
      tsFile.WriteLine("clippingSize " + _clippingSize.Width + " " + _clippingSize.Height);
      tsFile.WriteLine("\n# Number Of Sample");
      tsFile.WriteLine("numsample " + _numSamples.ToString());
      tsFile.WriteLine("\n# Number Of Point");
      tsFile.WriteLine("numpoint " + _numPoints.ToString());

      tsFile.WriteLine("\n# Connectivity Data");
      tsFile.WriteLine("_StartConnectivity");
      for(i=1;i<_numPoints;i++) {
        for(j=0;j<i;j++)
          if(_connectivity[i,j])
            tsFile.Write("1 ");
          else
            tsFile.Write("0 ");
        tsFile.WriteLine();
      }
      tsFile.WriteLine("_EndConnectivity");
      
      tsFile.Close();
      tsFile.Dispose();
      tsFile = null;

      // Save Training Set Data
      CSettings.status.statusProgress.Minimum = 0;
      CSettings.status.statusProgress.Maximum = _numSamples;
      CSettings.status.statusProgress.Step    = 1;
      CSettings.status.statusProgress.Value   = 0;
      CSettings.status.statusProgress.Visible = true;

      string dataPath = path + name + "_data\\";
      if(Directory.Exists(dataPath)) Directory.Delete(dataPath,true);
      Directory.CreateDirectory(dataPath);
      dataPath += name + "_";

      for(i=0;i<_numSamples;i++) {
        string dataNumber = i.ToString().PadLeft(4,'0');
        string imageFilenameDes = dataPath + dataNumber + ".jpg";
        string textFilename     = dataPath + dataNumber + ".txt";

        CSettings.status.statusLabel.Text = "Saving sample number " + dataNumber;
        CSettings.status.statusLabel.Refresh();
        CSettings.status.statusProgress.PerformStep();
        CSettings.status.statusProgress.Invalidate();

        File.Copy(((CSample)_sample[i]).pictureFilename,imageFilenameDes);

        tsFile = File.CreateText(textFilename);
        tsFile.WriteLine("_StartPoint");
        for(j=0;j<_numPoints;j++)
          tsFile.WriteLine(((CSample)_sample[i])[j][0].ToString("F5") + " " + ((CSample)_sample[i])[j][1].ToString("F5"));
        tsFile.WriteLine("_EndPoint");
        tsFile.Close();
        tsFile.Dispose();
        tsFile = null;
      }
      CSettings.status.Hide();
    }

    #endregion

    #region "Principal Component Analysis"

    public bool initializeTraining(double modelSize) {
      if(_numSamples <= 0 || _numPoints <= 0) return false;

      // Copy the label
      _trainingData = new CXYVector[_numSamples];
      int i,k,l,s;
      for(k=0;k<_numSamples;k++)
        _trainingData[k] = new CXYVector(_numPoints,((CSample)_sample[k]).points);

      // create a normal shape 
      /* Create A Circle Shape
       * Use This To Transform The "Center" Point Of The Mean Sample To Origin
       * The Mean Sample Orientation Will Be Fix Using Manual Orientation
       */
      double radius = modelSize;
      _normalShape = new CXYVector(_numPoints);
      for (i = 1; i < 2 * _normalShape.size; i += 2) {
        double angle = (i * System.Math.PI) / _normalShape.size;
        _normalShape[i / 2] = new CVector2(radius * System.Math.Sin(angle), radius * System.Math.Cos(angle));
      }

      // Make First Sample As The Mean Sample
      _mean = new CXYVector(_trainingData[0]);

      // Create the weight diagonal matrix
      // the matrix is reduced to vector
      _weight = new double[_numPoints];
      for (k = 0; k < _numPoints; k++) {
        double sumVar = 0.0;
        for (l = 0; l < _numPoints; l++) {
          double sigX = 0.0;
          double sigX2 = 0.0;
          for (s = 0; s < _numSamples; s++) {
            CVector2 tv = _trainingData[s][k].substractCopy(_trainingData[s][l]);
            double delta = tv.length2();
            sigX  += Math.Sqrt(delta);
            sigX2 += delta;
          }
          sumVar += (sigX2 - ((sigX * sigX) / _numSamples)) / _numSamples;
        }
        _weight[k] = 1.0 / sumVar;
      }

      _energy = 100000;

      return true;
    }

    public long realignAll() {
      int i;

      long start = CSettings.currentTimeMillis();
      
      CXYVector.realign(_trainingData[0],_mean,_weight);
      _newMean = new CXYVector(_trainingData[0]);
      for(i=1;i<_numSamples;i++) {
        CXYVector.realign(_trainingData[i],_mean,_weight);
        _newMean.add(_trainingData[i]);
      }
      _newMean.divide(_numSamples);

      return CSettings.currentTimeMillis() - start;
    }

    public void normalizeMean() {
      CXYVector.realign(_newMean,_normalShape,_weight);
      _energy = _mean.distance(_newMean);
      _mean = new CXYVector(_newMean);
    }

    public bool isConverge() {
      return (_energy < 10e-10);
    }

    public CPointDistributionModel principalComponentAnalysis(Size clippingSize,out long time) {
      long start = CSettings.currentTimeMillis();
      
      // Get Covarian Matrix
      CMatrix s = new CMatrix(_numPoints*2,false);
      for (int i = 0; i < _numSamples; i++) {
        CVector dx = new CVector(_trainingData[i].substractCopy(_mean));
        CMatrix dxdxT = dx.multiplyMatrix(dx);
        s.add(dxdxT);
      }
      s.divide(_numSamples);

      // Calculate Eigen
      CPointDistributionModel ret =  new CPointDistributionModel(clippingSize,_mean,CEigen.calculate(s),7,_connectivity);
      
      long end = CSettings.currentTimeMillis();
      time = end-start;

      return ret;
    }

    #endregion
  }

  public class CPointDistributionModel {
    #region "Attributes"

    private Size      _clippingSize;
    private int       _numPoints;
    private CXYVector _mean;
    private CEigen    _eigen;
    private double[]  _sqrtEigenValues;
    private int       _degreeOfFreedom;
    private bool[,]   _connectivity;

    #endregion

    #region "Constructor & Destructor"

    public CPointDistributionModel(Size clippingSize, CXYVector mean,CEigen eigen,int freedom, bool [,]connectivity) {
      _clippingSize    = new Size(clippingSize.Width,clippingSize.Height);
      _numPoints       = mean.size;
      _mean            = mean;
      _eigen           = eigen;
      _sqrtEigenValues = new double[_numPoints*2];
      for(int i=0;i<_numPoints*2;i++)
        _sqrtEigenValues[i] = Math.Sign(eigen.values[i]) * Math.Sqrt(Math.Abs(eigen.values[i]));
      _degreeOfFreedom = freedom;
      _connectivity    = (bool[,])connectivity.Clone();
    }

    #endregion

    #region "Properties"

    public Size clippingSize {
      get { return _clippingSize; }
      set { _clippingSize = value; }
    }

    public int numPoints {
      get { return _numPoints; }
    }

    public CXYVector mean {
      get { return _mean; }
      set { _mean = value; }
    }

    public CEigen eigen {
      get { return _eigen; }
    }

    public double[] sqrtEigenValues {
      get { return _sqrtEigenValues; }
    }

    public int freedom {
      get { return _degreeOfFreedom; }
      set { _degreeOfFreedom = value; }
    }

    #endregion

    #region "Methods"

    public CXYVector generateNewVariation(int n,double []b) {
      CXYVector ret    = new CXYVector(_mean);
      int       i,j,m  = _numPoints * 2;
      double    buff;
      double[]  pb     = new double[m];
      bool      isEven = true;

      if(n <= 0) n = _degreeOfFreedom;

      for(i=0;i<m;i++) {
        buff = 0.0;
        for(j=0;j<n;j++)
          buff += _eigen.vectors[i,j] * b[j];
        if(isEven)
          ret[i/2][0] += buff;
        else
          ret[i/2][1] += buff;
        isEven = !isEven;
      }

      return ret;
    }
    
    public bool isConnected(int i,int j) {
      if(i < 0 || i > _numPoints || j < 0 || j > _numPoints)
        return false;
      return _connectivity[i,j];
    }

    #endregion

    #region "File I/O"

    public static CPointDistributionModel open(string path) {
      if(!File.Exists(path)) return null;
      
      try
      {
        StreamReader tsFile = File.OpenText(path);
        bool         isStartMean = false,isStartEVal = false,isStartEVec = false,isStartConnect = false;
        int          ctr = 0,j;

        Size      buffClippingSize = new Size();
        int       buffNumPoints    = 0,buffFreedom = 0;
        CXYVector buffMean         = null;
        double [,]buffVec          = null;
        double  []buffVal          = null;
        bool   [,]buffConectivity  = null;

        while(!tsFile.EndOfStream) {
          string curLine = tsFile.ReadLine().Trim();
          if(curLine == "" || curLine[0] == '#') continue;
          string[] word = curLine.Split(' ');

          if(isStartMean) {
            if(word[0] == "_EndMean") {
              isStartMean = false;
              ctr = 0;
              continue;
            }
            buffMean[ctr][0] = double.Parse(word[0]);
            buffMean[ctr][1] = double.Parse(word[1]);
            ctr++;
          }else if(isStartEVec) {
            if(word[0] == "_EndEigenVectors") {
              isStartEVec = false;
              ctr = 0;
              continue;
            }
            for(j=0;j<word.Length;j++)
              buffVec[ctr,j] = double.Parse(word[j]);
            ctr++;
          }else if(isStartEVal) {
            if(word[0] == "_EndEigenValues") {
              isStartEVal = false;
              ctr = 0;
              continue;
            }
            buffVal[ctr] = double.Parse(word[0]);
            ctr++;
          }else if(isStartConnect) {
            if(word[0] == "_EndConnectivity") {
              isStartConnect = false;
              ctr = 0;
              continue;
            }
            for(j=0;j<word.Length;j++)
              if(word[j]=="1")
                buffConectivity[ctr,j] = buffConectivity[j,ctr] = true;
            ctr++;
          }else{
            switch(word[0]) {
              case "clippingSize" :
                buffClippingSize = new Size(int.Parse(word[1]),int.Parse(word[2]));
                break;
              case "numpoint" :
                buffNumPoints   = int.Parse(word[1]);
                buffMean        = new CXYVector(buffNumPoints);
                buffVec         = new double[buffNumPoints*2+1,buffNumPoints*2+1];
                buffVal         = new double[buffNumPoints*2+1];
                buffConectivity = new bool[buffNumPoints*2,buffNumPoints*2];
                break;
              case "degOfFreedom" :
                buffFreedom = int.Parse(word[1]);
                break;
              case "_StartMean" :
                isStartMean = true;
                ctr = 0;
                break;
              case "_StartEigenVectors" :
                isStartEVec = true;
                ctr = 0;
                break;
              case "_StartEigenValues" :
                isStartEVal = true;
                ctr = 0;
                break;
              case "_StartConnectivity" :
                isStartConnect = true;
                ctr = 1;
                break;
            }
          }
        }
        tsFile.Close();
        tsFile.Dispose();
        tsFile = null;
        return new CPointDistributionModel(
                     buffClippingSize,
                     buffMean,
                     new CEigen(
                           buffNumPoints*2,
                           buffVec,
                           buffVal),
                     buffFreedom,
                     buffConectivity);
      }catch(Exception) {
        return null;
      }
    }

    public void saveToDisk(string path) {
      // Save PDM Data
      int i,j,m = _eigen.size;
      StreamWriter tsFile = null;
      if(File.Exists(path))
        File.Delete(path);
        
      tsFile = File.CreateText(path);
      tsFile.WriteLine("# Clipping Size");
      tsFile.WriteLine("clippingSize " + _clippingSize.Width + " " + _clippingSize.Height);

      tsFile.WriteLine("\n# Number Of Point");
      tsFile.WriteLine("numpoint " + _numPoints.ToString());
      
      tsFile.WriteLine("\n# Degree Of Freedom");
      tsFile.WriteLine("degOfFreedom " + _degreeOfFreedom.ToString());

      tsFile.WriteLine("\n# Mean Model");
      tsFile.WriteLine("_StartMean");
      for(i=0;i<_numPoints;i++)
        tsFile.WriteLine(_mean[i][0] + " " + _mean[i][1]);
      tsFile.WriteLine("_EndMean");
      
      tsFile.WriteLine("\n# Model Variation");
      tsFile.WriteLine("_StartEigenVectors");
      for(i=0;i<m;i++) {
        for(j=0;j<m;j++)
          tsFile.Write(_eigen.vectors[i,j] + " ");
        tsFile.WriteLine();
      }
      tsFile.WriteLine("_EndEigenVectors");

      tsFile.WriteLine("\n_StartEigenValues");
      for(i=0;i<m;i++)
        tsFile.WriteLine(_eigen.values[i]);
      tsFile.WriteLine("_EndEigenValues");

      tsFile.WriteLine("\n# Connectivity Data");
      tsFile.WriteLine("_StartConnectivity");
      for(i=1;i<_numPoints;i++) {
        for(j=0;j<i;j++)
          if(_connectivity[i,j])
            tsFile.Write("1 ");
          else
            tsFile.Write("0 ");
        tsFile.WriteLine();
      }
      tsFile.WriteLine("_EndConnectivity");

      tsFile.Close();
      tsFile.Dispose();
      tsFile = null;
    }

    #endregion
  }
  
  public class CActiveShapeModel {
    #region "Attributes"

    private CPointDistributionModel _PDMData;
    private Bitmap                  _image;
    private CXYVector               _ASMResult;
    private int                     _cx,_cy;
    private double                  _energy;
    private bool                    _usePreviousResult;
    private int                     _stepCounter;
    private int                     _maxStep;
    private int                     _edgeThreshold;
    private int                     _detectionLimit;

    // internal processing unit
    private CXYVector _XdX;
    private int       _imageWidth,_imageHeight,_size;
    private int    [,]_bitmap;
    private double  []_weight;

    // DEBUG
    public CXYVector lastResult;
    public CXYVector detectedEdge;
    public CXYVector alignedModel;
    public CXYVector newModelInImageParameter;
    public CXYVector movement;
    // END DEBUG

    //private StreamWriter calcMove;

    #endregion

    #region "Constructor & Destructor"

    public CActiveShapeModel(string PDMPath) {
      _image             = null;
      PDMData            = CPointDistributionModel.open(PDMPath);
      _cx                = _PDMData.clippingSize.Width/2;
      _cy                = _PDMData.clippingSize.Height/2;
      _energy            = 0;
      _usePreviousResult = true;
      _stepCounter       = 0;
      _maxStep           = 10;
      _edgeThreshold     = 20;
      _detectionLimit    = 10;
    }

    public CActiveShapeModel(CPointDistributionModel PDM) {
      _image             = null;
      PDMData            = PDM;
      _cx                = _PDMData.clippingSize.Width/2;
      _cy                = _PDMData.clippingSize.Height/2;
      _energy            = 0;
      _usePreviousResult = true;
      _stepCounter       = 0;
      _maxStep           = 10;
      _edgeThreshold     = 20;
      _detectionLimit    = 10;
    }

    #endregion

    #region "Properties"

    public CPointDistributionModel PDMData {
      get { return _PDMData; }
      set {
        if(value == null)
          throw new Exception("PDM Data Not Found!");
        _PDMData = value;
        resetModel();
        _size = _ASMResult.size;
        _XdX = new CXYVector(_size);
        _weight = new double[_PDMData.numPoints];
        int i;
        for (i = 0; i < _PDMData.numPoints; i++)
          _weight[i] = 1.0;
      }
    }

    public CXYVector ASMResult {
      get { return _ASMResult; }
    }

    public int cx {
      get { return _cx; }
      set { _cx = value; }
    }

    public int cy {
      get { return _cy; }
      set { _cy = value; }
    }

    public double energy {
      get { return _energy; }
    }

    public bool usePreviousResult {
      get { return _usePreviousResult; }
      set { _usePreviousResult = value; }
    }

    public int step {
      get { return _stepCounter; }
    }

    public int maxStep {
      get { return _maxStep; }
      set { _maxStep = value; }
    }

    public int edgeThreshold {
      get { return _edgeThreshold; }
      set { _edgeThreshold = value; }
    }

    public int detectionLimit {
      get { return _detectionLimit; }
      set { _detectionLimit = value; }
    }

    #endregion

    #region "Methods"

    private unsafe void getBitmap() {
      // lock source bitmap data
			BitmapData imageData = _image.LockBits(
				new Rectangle( 0, 0, _image.Width, _image.Height ),
				ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb );

			// get width and height
			_imageWidth  = imageData.Width;
			_imageHeight = imageData.Height;

			int offset = imageData.Stride - _imageWidth * 4;

			byte *src = (byte *) imageData.Scan0.ToPointer( );

      _bitmap = new int[_imageWidth,_imageHeight];
			// for each line
      for ( int y = 0; y < _imageHeight; y++ ) {
				// for each pixel
				for ( int x = 0; x < _imageWidth; x++, src +=4)
          _bitmap[x,y] = src[0];
        src += offset;
			}

      // unlock source image
			_image.UnlockBits( imageData );
    }

    private int getBit(int x,int y) {
      if (x < 0 || x >= _imageWidth || y < 0 || y >= _imageHeight)
        return 0;
      return _bitmap[x,y];
    }

    private void scanForEdge(double x,double y,ref double dx,ref double dy) {
      int strongestEdge = getBit((int)x,(int) y);
      int currEdge,prevP,prevM;
      double strongestdx = 0;
      double strongestdy = 0;

      prevM = prevP = getBit((int)x, (int)y);
      for (int i = 1; i < _detectionLimit; i++) {
        double _dx = dx * i;
        double _dy = dy * i;

        // Scanning For The Strongest Edge
        // Search outward want a 1->0 transition
        currEdge = getBit((int)(x + _dx), (int)(y + _dy));
        if ((prevP > strongestEdge) && (prevP > _edgeThreshold) && (currEdge < _edgeThreshold)) {
          strongestEdge = prevP;
          strongestdx = _dx;
          strongestdy = _dy;
        }
        prevP = currEdge;

        // Search inward want a 0->1 transition
        currEdge = getBit((int)(x - _dx), (int)(y - _dy));
        if ((currEdge > strongestEdge) && (prevM < _edgeThreshold) && (currEdge > _edgeThreshold)) {
          strongestEdge = currEdge;
          strongestdx = -_dx;
          strongestdy = -_dy;
        }
        prevM = currEdge;
      }
      dx = strongestdx;
      dy = strongestdy;
    }

    private int calculateMovement(CXYVector xdX) {
      int size = _ASMResult.size;
      int detectedEdgeCnt = 0;
      
      for (int i = 0; i < size; i++) {
        xdX[i] = CVector2.vNormal(_ASMResult[(i + size - 1) % size],
                      _ASMResult[i],
                      _ASMResult[(i + 1) % size]);
        double dx = xdX[i][0];
        double dy = xdX[i][1];
        
        scanForEdge(_ASMResult[i][0], _ASMResult[i][1],
                    ref dx,ref dy);
        if(dx != 0 && dy != 0)
          detectedEdgeCnt++;

        xdX[i][0] = dx;
        xdX[i][1] = dy;
        xdX[i].add(_ASMResult[i]);
      }
      return detectedEdgeCnt;
    }

    public void resetSearch(Bitmap image) {
      _image = new Bitmap(image,_PDMData.clippingSize.Width,_PDMData.clippingSize.Height);

      getBitmap();
      _stepCounter = 0;
      _energy = 10e12;
      if(!_usePreviousResult) resetModel();
    }

    public void resetModel() {
      _ASMResult   = new CXYVector(_PDMData.mean);
      _ASMResult.add(new CVector2(_cx,_cy));
    }

    public bool doStep() {
      if(_stepCounter >= maxStep) return false;
      _stepCounter++;
      if(isConverge()) return false;
      
      int i,j;
      // Calculate Movement
      int detectedEdgeCnt = calculateMovement(_XdX);
      
      // Compute Change
      CXYVector  currentShape = new CXYVector(_PDMData.mean);
      CMatrix3x3 pose = CXYVector.realign(currentShape, _XdX,_weight);

      // Get Residual Adjustment
      CXYVector XdX = new CXYVector(_XdX);
      XdX.transform(pose.inverse());
      double []dx = XdX.substractDouble(_PDMData.mean);

      // Translate Into Model Parameter
      double  []db         = new double[_PDMData.freedom];
      double [,]vectorsPtr = _PDMData.eigen.vectors;
      double    dimension  = _size*2;
      for(i=0;i<_PDMData.freedom;i++) {
        db[i] = 0;
        for(j=0;j<dimension;j++)
          db[i]+= vectorsPtr[j,i] * dx[j];
      }

      // Find Out If Parameter Is Out Of Limit
      double dm = 0.0;
      for (i = 0; i < _PDMData.freedom; i++)
        dm += (db[i] * db[i]) / _PDMData.eigen.values[i];

      // If It Does, Apply Limit
      dm = Math.Sqrt(dm);
      if (dm > 3.0)
        for (i = 0; i < _PDMData.freedom; i++)
            db[i] *= 3.0 / dm;

      // Update Parameter
      currentShape = PDMData.generateNewVariation(-1,db);
      CXYVector.realign(currentShape, _XdX,_weight);
      //currentShape.transform(pose);
      _energy    = _ASMResult.distance(currentShape);
      _ASMResult = currentShape;

      return (detectedEdgeCnt > (_ASMResult.size/10));
    }

    public void doSearch(Bitmap image) {
      // resize image to sample resolution
      resetSearch(image);
      // optimize
      bool res = false;
      CXYVector _prevASMResult = new CXYVector(_ASMResult);
      while(_stepCounter < _maxStep && !isConverge()) res = doStep() || res;
      if(!res) {
        _ASMResult = new CXYVector(_prevASMResult);
        _energy = 0;
      }
    }

    public bool isConverge() {
      return (_energy < 10);;
    }

    public bool isConnected(int i,int j) {
      return _PDMData.isConnected(i,j);
    }

    #endregion    
  }
}
