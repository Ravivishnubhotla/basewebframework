using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLHotSpot
{
    public class CPData : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public SolidColorBrush BrandColor{ get; set; }
        public int OCP { get; set; }
        private string cpText;
        public string CPText
        {
            get { return cpText; }
            set { 
                cpText = value;
                NotifyPropertyChanged("CPText");
            }
        }

        public int ncp;
        public int NCP
        {
            get { return ncp; }
            set {
                ncp = value;
                NotifyPropertyChanged("NCP");
            }
        }

        

        #region INotifyPropertyChanged 接口实现

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private static ObservableCollection<CPData> cpDatas = new ObservableCollection<CPData>();

        public static ObservableCollection<CPData> GetAllData()
        {
            cpDatas.Clear();

            foreach (BrandInfo brandInfo in BrandInfo.BrandInfos)
            {
                CPData cpData = new CPData();
                cpData.Name = brandInfo.Name;
                cpData.BrandColor = brandInfo.BrandColor;
                Random random = new Random(cpData.GetHashCode());
                cpData.OCP = random.Next(20, 100);
                cpData.NCP = cpData.OCP;
                cpData.CPText = string.Format("原有竞争力 ： {0}",cpData.OCP);
                cpDatas.Add(cpData);           
            }

            return cpDatas;
        }


        public static void CaculateAllData()
        {
            foreach (CPData cpData in cpDatas)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                cpData.NCP = random.Next(20, 100);
                cpData.CPText = string.Format("原有竞争力：{0} 现有竞争力:{1}", cpData.OCP, cpData.NCP);
            }
        }
    }
}
