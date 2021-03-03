using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Task4Console.Buisness.ReportWatching
{
    public class ReportWatcher
    {
        public delegate void ReportFileAddedHandler(string path, string fileName);

        public event ReportFileAddedHandler ReportFileAdded;

        private FileSystemWatcher _watcher;
        public ReportWatcher(FileSystemWatcher systemWatcher)
        {
            this._watcher = systemWatcher;
            _watcher.Path = ConfigurationManager.AppSettings.Get("Path");
            _watcher.Filter = $"*{ConfigurationManager.AppSettings.Get("FileFormat")}";
            _watcher.Created += new FileSystemEventHandler(OnCreated);
        }

        public void StartWatch()
        {
            this._watcher.EnableRaisingEvents = true;
        }

        public void StopWatch()
        {
            this._watcher.EnableRaisingEvents = false;
        }

        private void OnCreated(object source, FileSystemEventArgs e)
        {
            ReportFileAdded?.Invoke(e.FullPath, e.Name);
        }
    }
}
