using System;
using System.IO;
using System.Text;

namespace TriathlonTrainingsApp
{
    class WriteActivityData
    {
        public string WritePathDistanceData { get; set; }
        public string WritePathDurationData { get; set; }

        public WriteActivityData(string writePathDistanceData, string writePathDurationData)
        {
            WritePathDistanceData = writePathDistanceData;
            WritePathDurationData = writePathDurationData;
        }
        public void WriteData(string path, double activityData)
        {
            try
            {
                using (var writeFile = new StreamWriter(path, true, Encoding.Default))
                {
                    writeFile.WriteLine(activityData.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
