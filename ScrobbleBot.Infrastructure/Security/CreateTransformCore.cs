using System;
using System.Security.Cryptography;

namespace ScrobbleBot.Infrastructure.Security
{
    public static class CreateTransformCores
    {
        private static ICryptoTransform CreateTransformCore(
            CipherMode cipherMode,
            PaddingMode paddingMode,
            byte[] key,
            byte[] iv,
            int blockSize,
            bool encrypting)
        {
            //SafeAlgorithmHandle algorithm = AesBCryptModes.GetSharedHandle(cipherMode);

            //BasicSymmetricCipher cipher = new BasicSymmetricCipherBCrypt(algorithm, cipherMode, blockSize, key, false, iv, encrypting);
            //return UniversalCryptoTransform.Create(paddingMode, cipher, encrypting);
            throw new NotImplementedException();
        }
    }
}