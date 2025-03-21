using CryptoNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo.Nugets.CryptoNet_
{
    /// <summary>
    /// github <a href="https://github.com/itbackyard/CryptoNet">
    /// website<a href="https://itbackyard.github.io/CryptoNet/docs/introduction.html">
    /// </summary>
    public class CryptoNet_
    {

        public CryptoNet_()
        {

        }

        public static void Demo()
        {
            var confidentialMessage = "Watson, can you hear me?";

            Console.WriteLine($"Original: {confidentialMessage}");

            var sharedKey = CreateKey();

            var cypher = SimulateEncryptor(sharedKey, confidentialMessage);

            Console.WriteLine("Encrypted: " + BitConverter.ToString(cypher).Replace("-", ""));

            var decryptedMessage = SimulateDecryptor(sharedKey, cypher);

            Console.WriteLine($"Decrypted: {decryptedMessage}");
        }

        static string CreateKey()
        {
            var encoder = new CryptoNetAes();

            return encoder.ExportKey();
        }

        // Demonstrates how to create a cypher with a key.
        static byte[] SimulateEncryptor(string key, string message)
        {
            var encryptClient = new CryptoNetAes(key);

            return encryptClient.EncryptFromString(message);
        }

        // Demonstrates how to decrypt a cypher with a key.
        static string SimulateDecryptor(string key, byte[] encrypted)
        {
            var decryptClient = new CryptoNetAes(key);

            return decryptClient.DecryptToString(encrypted);
        }

    }
}



