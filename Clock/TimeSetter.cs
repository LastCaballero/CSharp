using System ;
using System.Threading ;
using clock ;

namespace timesetter {
    class TimeChanger {
        MainWindow Main ;
        public TimeChanger(MainWindow main) {
            Main = main ;
            new Thread(SetTime).Start() ;
        }
        public void SetTime() {
            while( true ) {
                DateTime now = DateTime.Now ;
                Main.Dispatcher.Invoke(
                    () => {
                        Main.Hour.Content = string.Format("{0,2}",now.Hour) ;
                        Main.Minute.Content = string.Format("{0,2}",now.Minute) ;
                        Main.Second.Content = string.Format("{0,2}",now.Second) ;
                    }
                ) ;    
                Thread.Sleep(1000) ;
            }          
        }
    }
}
