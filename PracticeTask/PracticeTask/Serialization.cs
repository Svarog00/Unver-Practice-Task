using PointClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace PracticeTask
{
    public class Serialization
    {
        public void SaveData(SavedData data, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create); //open stream to create a save file
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, data); //serialize savedData in fs file
                fs.Close(); //close file stream
            }
            catch (Exception Error)
            {
                System.Windows.MessageBox.Show(Error.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        public SavedData LoadData(string path)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                SavedData data = new SavedData();
                try
                {
                    data = (SavedData)formatter.Deserialize(fs);
                    return data;
                }
                catch (Exception Error)
                {
                    System.Windows.MessageBox.Show(Error.Message);
                    return null;
                }
                finally
                {
                    fs.Close();
                }
            }
            else
                return null;
        }

        public string LoadReference()
        {
            string text;
            FileStream fs = File.OpenRead("Reference.txt");
            try
            {
                byte[] array = new byte[fs.Length];
                fs.Read(array, 0, array.Length);
                return text = Encoding.UTF8.GetString(array);
            }
            catch(Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message);
                return text = null;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
