using System;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace ScrobbleBot.Infrastructure.Security
{
    /// <summary>
    /// This represents the <see cref="AesImplementation"/> class.
    /// </summary>
    public class AesImplementation
    {
        // Standard value's
        private KeySizes[] LegalBlockSizesValue = s_legalBlockSizes.CloneKeySizesArray();
        private KeySizes[] LegalKeySizesValue = s_legalKeySizes.CloneKeySizesArray();
        private const int KeySize = 128;
        private const int BlockSizeValue = 128;
        private const int BitsPerByte = 8;

        // Key
        private byte[] _key;
        private byte[] _iv;

        /// <summary>
        /// Generate a key for the aes algorithm.
        /// </summary>
        public void GenerateKey()
        {
            byte[] key = new byte[KeySize / BitsPerByte];
            RandomNumberGenerator.Fill(key);
            _key = key;
        }

        /// <summary>
        /// Generate a iv key for the aes algorithm.
        /// </summary>
        public void GenerateIv()
        {
            byte[] iv = new byte[BlockSizeValue / BitsPerByte];
            RandomNumberGenerator.Fill(iv);
            _iv = iv;
        }

        private ICryptoTransform CreateTransform(byte[] rgbKey, byte[] rgbIV, bool encrypting)
        {
            // note: rbgIV is guaranteed to be cloned before this method, so no need to clone it again

            if (rgbKey == null)
                throw new ArgumentNullException(nameof(rgbKey));

            long keySize = rgbKey.Length * (long)BitsPerByte;
            if (keySize > int.MaxValue || !((int)keySize).IsLegalSize(this.LegalKeySizes))
                throw new ArgumentException("SR.Cryptography_InvalidKeySize", nameof(rgbKey));

            if (rgbIV != null)
            {
                long ivSize = rgbIV.Length * (long)BitsPerByte;
                if (ivSize != BlockSizeValue)
                    throw new ArgumentException("SR.Cryptography_InvalidIVSize", nameof(rgbIV));
            }
            throw new NotImplementedException();
            //return CreateTransformCore(Mode, Padding, rgbKey, rgbIV, BlockSizeValue / BitsPerByte, encrypting);
        }

        private static readonly KeySizes[] s_legalBlockSizes = { new KeySizes(128, 128, 0) };
        private static readonly KeySizes[] s_legalKeySizes = { new KeySizes(128, 256, 64) };

        public virtual KeySizes[] LegalKeySizes => (KeySizes[])LegalKeySizesValue.Clone();
    }
}