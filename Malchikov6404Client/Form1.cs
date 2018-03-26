using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Numerics;

namespace Malchikov6404Client
{
    public partial class Client : Form
    {
        // Это КЛИЕНТ только на генерацию ключей, шифрование и передачу
        public int sendport = 9081;
        public int keyport = 9082;
        private byte[] messagecc = null;
        private byte[] encrypted, decrypted; // the encrypted bytes

        private byte[] encMessage; // the encrypted bytes
        private byte[] decMessage; // the decrypted bytes - s/b same as message
        private byte[] key;
        private byte[] iv;
        private byte[] superkey1;
        private BigInteger superkey;

        int i = 0;

        private BigInteger newBigInt;
        private static TcpClient tcp_client;
        private static FileStream fs_stream;
        private static NetworkStream ntw_stream;
        private BigInteger _Ekey, _Pkey, _Qkey, _Nkey, _Phikey, _Dkey, _Xkey, _Ykey, _NODkey;
        private double[] tmpArray;
       
        public Client()
        {
            InitializeComponent();
            String strHostName;
            strHostName = Dns.GetHostName();
            System.Net.IPAddress ip = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName()).AddressList[0];
            myIP.Text += ip.ToString();
            ipadress.Text = ip.ToString();
            logs.Text += "===Начало работы===\r\n";

        }
        private void getFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                filepath.Text = openFileDialog1.FileName;
                sr.Close();
            }
        }
        private void sendFile_Click(object sender, EventArgs e)//тестовый
        {
            if ((ipadress.Text != "") && (filepath.Text != ""))
            {
                tcp_client = new TcpClient();
                try
                {
                    tcp_client.Connect(IPAddress.Parse(ipadress.Text), sendport);
                    logs.Text += "Подключено к серверу\r\n";
                }
                catch (Exception ex)
                {
                    logs.Text += "ERROR =" + ex.Message;
                }
                logs.Text += "Отправка...\r\n";
                ntw_stream = tcp_client.GetStream();
                fs_stream = new FileStream(filepath.Text, FileMode.Open, FileAccess.Read);
                BinaryReader bnr_reader = new BinaryReader(fs_stream);
                FileInfo inf = new FileInfo(filepath.Text);
                string HeaderData = string.Format("{0}&{1}&", inf.Name, inf.Length);
                List<byte> Bytes = new List<byte>();
                Bytes.WholeAdding(new MemoryStream(Encoding.ASCII.GetBytes(HeaderData)));
                Bytes.WholeAdding(fs_stream);
                byte[] DBytes = Bytes.ToArray();
                ntw_stream.Write(DBytes, 0, DBytes.Length);
                logs.Text += "Файл вроде отправлен.\r\n";
                Thread.Sleep(500);
                tcp_client.Close();
                ntw_stream.Close();
                fs_stream.Close();
                logs.Text += "Потоки закрыты.\r\n ";
            }
            else { logs.Text += "Поля IP адреса и путь файла неправильно заполнены\r\n"; }
        }
        private void generateKey_Click(object sender, EventArgs e)
        {
            if (ipadress.Text != "") 
            {
                try
                {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipadress.Text), keyport);
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipPoint);
                    string message = "1";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    socket.Send(data);
                    data = new byte[256]; // буфер для ответа
                    int bytes = 0; // количество полученных байт
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0); Thread.Sleep(100);
                        _Ekey = new BigInteger(data);
                        bytes = socket.Receive(data, data.Length, 0); Thread.Sleep(100);
                        _Nkey = new BigInteger(data);
                        bytes = socket.Receive(data, data.Length, 0); Thread.Sleep(100);
                        _Dkey = new BigInteger(data);

                    }
                    while (socket.Available > 0);
                    logs.Text += "Ключи получены: \r\n";
                    logs.Text += "E= " + _Ekey + "N= " + _Nkey + "\r\n";

                    // закрываем сокет
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
                catch (Exception ex)
                {
                    logs.Text += "ERROR=" + ex.Message + "\r\n";
                }
            }
             
            else { logs.Text += "Поля IP адреса и путь файла неправильно заполнены\r\n"; }
           
        }
        double gcd(double a, double b, out double x, out double y)
        {
            if (a == 0)
            {
                x = 0; y = 1;
                return b;
            }
            double x1, y1;
            double d = gcd(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;

        }
        //теперь не используется
        static byte[] EncryptToBytes_Aes(byte[] plainText, byte[] Key,byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }
        //теперь не используется
        private void goRSAbutton_Click(object sender, EventArgs e)//отправка файла
        {
            if ((ipadress.Text != "") && (filepath.Text != ""))
            {
                                  
                        //отправка 
                        if ((ipadress.Text != "") && (filepath.Text != ""))
                        {
                            tcp_client = new TcpClient();
                            try
                            {
                                tcp_client.Connect(IPAddress.Parse(ipadress.Text), sendport);
                                logs.Text += "Подключено к серверу\r\n";
                            }
                            catch (Exception ex)
                            {
                                logs.Text += "ERROR =" + ex.Message;
                            }
                            logs.Text += "Отправка...\r\n";
                            ntw_stream = tcp_client.GetStream();
                            fs_stream = new FileStream(filepath.Text, FileMode.Open, FileAccess.Read);
                            BinaryReader bnr_reader = new BinaryReader(fs_stream);
                            FileInfo inf = new FileInfo(filepath.Text);
                            string HeaderData = string.Format("{0}&{1}&", inf.Name, inf.Length);
                            List<byte> Bytes = new List<byte>();
                            Bytes.WholeAdding(new MemoryStream(Encoding.ASCII.GetBytes(HeaderData)));
                            Bytes.WholeAdding(fs_stream);
                            byte[] DBytes = Bytes.ToArray();
                            ntw_stream.Write(DBytes, 0, DBytes.Length);
                            logs.Text += "Файл вроде отправлен.\r\n";
                            Thread.Sleep(500);
                            tcp_client.Close();
                            ntw_stream.Close();
                            fs_stream.Close();
                            logs.Text += "Потоки закрыты.\r\n ";
                        }
                        else { logs.Text += "Поля IP адреса и путь файла неправильно заполнены\r\n"; }

                        // отправка закончена
                    
                    
                
            }
            else { logs.Text += "Поля IP адреса и путь файла неправильно заполнены\r\n"; }
            }
        BigInteger Gcd(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            Console.WriteLine(i++);

            {
                if (b < a)
                {
                    var t = a;
                    a = b;
                    b = t;
                }

                if (a == 0)
                {
                    x = 0;
                    y = 1;
                    return b;
                }

                BigInteger gcd = Gcd(b % a, a, out y, out x);

                //BigInteger newY = x;
                //BigInteger newX
                
                y = y - (b / a) * x;

                //x = newX;
                //y = newY;
                return gcd;
            }
        }
        BigInteger IteratGCD(BigInteger a, BigInteger b, out BigInteger dx, out BigInteger dy)
        {	/* calculates a * *x + b * *y = gcd(a, b) = *d */
	        BigInteger q, r, x1, x2, y1, y2;
	        if (b == 0) //если один из множителей равен 0
	        {
		        dx = 1; dy = 0;
		        return a;
	        }
	        x2 = 1; x1 = 0; y2 = 0; y1 = 1;

	        while (b > 0) 
	        {
		        q = a / b; 
		        r = a - q * b;
		        dx = x2 - q * x1; 
		        dy = y2 - q * y1;
		        //промежуточный вывод
		        a = b; b = r;
		        x2 = x1; x1 = dx; y2 = y1; y1 = dy;
		
	        }	//end while (b>0)

            dx = x2; dy = y2;
            return a;
        }	//end alg_evklid
        Byte[] getPositiveBigInt(Byte[] arr)
        {
            byte[] bytes = arr;
            byte[] temp = new byte[bytes.Length];
            BigInteger test = new BigInteger(arr);
            if (test < 0)
            {
                if ((bytes[bytes.Length - 1]) > 0)
                {
                    Array.Copy(bytes, temp, bytes.Length);
                    bytes = new byte[temp.Length + 1];
                    Array.Copy(temp, 0,bytes,0, temp.Length);
                }
            }
            else { bytes = arr; }
            test = new BigInteger(bytes);
            return bytes;
        }
        private void genSuperkeyandSent_Click(object sender, EventArgs e)
        {
            
           byte [] message = File.ReadAllBytes(filepath.Text);
           var rijndael = new RijndaelManaged();
            
                rijndael.GenerateKey();
                newBigInt = new BigInteger(rijndael.Key.Concat(new byte[] { 0x00 }).ToArray());
                int rrr = rijndael.Key.Length;
                rijndael.GenerateIV();
                key = rijndael.Key;
                iv = rijndael.IV;
                encMessage = EncryptBytes(rijndael, message);
            
            File.WriteAllBytes(filepath.Text, encMessage);
           
            BigInteger b_Ekey = _Ekey;
            BigInteger b_Nkey = _Nkey;
            
                superkey = BigInteger.ModPow(newBigInt, b_Ekey, b_Nkey);
               // BigInteger check = BigInteger.ModPow(superkey, _Dkey, b_Nkey);
               // if (newBigInt != check) { logs.Text += " Опять ошибка с ключом \r\n"; }
            
            superkeyl.Text += Convert.ToString(superkey);
            byte[] inivector = iv;
            superkey1 = superkey.ToByteArray();
            int ee = superkey1.Length;
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(ipadress.Text), keyport);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
                socket.Send(superkey1);
                Thread.Sleep(100);
                socket.Send(inivector);
                while (socket.Available > 0) ;
                logs.Text += " Отправлен суперключ \r\n";
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                logs.Text += "ERROR=" + ex.Message + "\r\n";
            }
        }
        public static byte[] EncryptBytes(byte[] SourceBytes, byte[] Key, byte[] IV, int StartPosition, int Count)
        {
            using (RijndaelManaged aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                using (var stream = new MemoryStream())
                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    encrypt.Write(SourceBytes, StartPosition, Count);
                    encrypt.FlushFinalBlock();
                    return stream.ToArray();
                }
            }
        }
        public static byte[] DecryptBytes(byte[] SourceBytes, byte[] Key, byte[] IV, int StartPosition, int Count)
        {
            using (RijndaelManaged aesAlg = new RijndaelManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                using (var stream = new MemoryStream())
                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
                {
                    encrypt.Write(SourceBytes, StartPosition, Count);
                    encrypt.FlushFinalBlock();
                    return stream.ToArray();
                    stream.Close();
                }
            }
        }
        // тестовый
        private void CryptDecryptFileTest_Click(object sender, EventArgs e)
        {
            Aes myAes = Aes.Create();
            byte [] message = File.ReadAllBytes(filepath.Text);
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.GenerateKey();
                rijndael.GenerateIV();
                key = rijndael.Key;
                iv = rijndael.IV;
                encMessage = EncryptBytes(rijndael, message);
            }
            File.WriteAllBytes(filepath.Text, encMessage);
            encMessage = File.ReadAllBytes(filepath.Text);
            using (var rijndael = new RijndaelManaged())
            {
                rijndael.Key = key;
                rijndael.IV = iv;
                decMessage = DecryptBytes(rijndael, encMessage);
            }
            File.WriteAllBytes(filepath.Text, decMessage);
        }
        ///////тест метода из инета который работает! Используем его
        private static byte[] EncryptBytes(SymmetricAlgorithm alg,byte[] message)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }

            if (alg == null)
            {
                throw new ArgumentNullException("alg");
            }

            using (var stream = new MemoryStream())
            using (var encryptor = alg.CreateEncryptor())
            using (var encrypt = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }

        private static byte[] DecryptBytes(SymmetricAlgorithm alg,byte[] message)
        {
            if ((message == null) || (message.Length == 0))
            {
                return message;
            }

            if (alg == null)
            {
                throw new ArgumentNullException("alg");
            }

            using (var stream = new MemoryStream())
            using (var decryptor = alg.CreateDecryptor())
            using (var encrypt = new CryptoStream(stream, decryptor, CryptoStreamMode.Write))
            {
                encrypt.Write(message, 0, message.Length);
                encrypt.FlushFinalBlock();
                return stream.ToArray();
            }
        }
        //////конец метода из инета


    }
}
