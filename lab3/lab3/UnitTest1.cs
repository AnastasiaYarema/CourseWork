using System;
using Xunit;

namespace lab3PasswordHash
{
    public class PasswordHash
    {
        [Fact]
        public void InitRunsWithAlmostNullableParams()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("", 0);
            Assert.NotNull(IIG.PasswordHashingUtils.PasswordHasher.GetHash("test"));
        }

        [Fact]
        public void InitRunsWithCustomParams()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test", 1488);
            Assert.NotNull(IIG.PasswordHashingUtils.PasswordHasher.GetHash("test"));
        }

        [Fact]
        public void SamePasswordReturnsTrue()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.True(hash1.Equals(hash2));
        }


        [Fact]
        public void DifferentPasswordReturnsFalse()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test1");
            Assert.False(hash1.Equals(hash2));
        }

        [Fact]
        public void SameInitTwiceReturnsTrue()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test", 0);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("method");
            IIG.PasswordHashingUtils.PasswordHasher.Init("test", 0);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("method");
            Assert.True(hash1.Equals(hash2));
        }

        [Fact]
        public void SameSaltReturnsTrue()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test1", 0);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init("test1", 0);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.True(hash1.Equals(hash2));
        }

        [Fact]
        public void DifferentSaltReturnsFalse()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test", 0);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init("another", 0);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.False(hash1.Equals(hash2));
        }


        [Fact]
        public void SameAdlerModReturnsTrue()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 1488);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 1488);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.True(hash1.Equals(hash2));
        }


        [Fact]
        public void DifferentSmallerAdlerModReturnsFalse()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 110);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 111);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.False(hash1.Equals(hash2));
        }

        [Fact]
        public void DifferentAdlerModInInitReturnsFalse()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 999999999);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init(null, 199999999);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.False(hash1.Equals(hash2));
        }

        [Fact]
        public void SameSaltAdlerModReturnsTrue()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test1", 9999999);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init("test1", 9999999);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.True(hash1.Equals(hash2));
        }

        [Fact]
        public void DifferentSaltAdlerModReturnsFalse()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("test1fafas", 9999999);
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            IIG.PasswordHashingUtils.PasswordHasher.Init("test2sfva", 9999999);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("test");
            Assert.False(hash1.Equals(hash2));
        }
        
        [Fact]
        public void GetHashWithSameParams()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "test", 1);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "test", 1);
            Assert.True(hash1.Equals(hash2));
        }

        [Fact]
        public void GetHashWithDifferentSaltParams()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "test");
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "salt");
            Assert.False(hash1.Equals(hash2));
        }

        [Fact]
        public void GetHashWithDifferentAdlerModParams()
        {
            String hash1 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "test", 1);
            String hash2 = IIG.PasswordHashingUtils.PasswordHasher.GetHash("password", "test", 222);
            Assert.False(hash1.Equals(hash2));
        }

        [Fact]
        public void GetHashForVeryLongString()
        {
            IIG.PasswordHashingUtils.PasswordHasher.Init("", 0);
            Assert.NotNull(IIG.PasswordHashingUtils.PasswordHasher.GetHash("kjasfbsjanfkjasnfkjasnfkjnfkjdsanfkjasnkjfdnaksjfnkasnfkjdasnfkjasnkjfdnkjfnaskjfnakjsnfkjdanfkjsanfkjasnfkjsandfkjansdfkasnjnasdkjfnkasjdgnajknfkasdnfkjasnkandfkjasnfkjankjsdfnkjsdnjaklvn akljsvnalksjnklasdnkadjlnaksjfndklsjfnajknflaks"));
        }
    }
}
