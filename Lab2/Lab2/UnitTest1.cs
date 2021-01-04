using Xunit;
using System;

namespace Lab2
{
    public class UnitTest1
    {
        [Fact]
        public void ConstructorNormalRun()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);

            Assert.False(mbf.GetFlag());
        }


        [Fact]
        public void ConstructorNormalRunWithTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            
            Assert.True(mbf.GetFlag());
        }

        [Fact]
        public void ConstructorMaxLength()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(17179868703, false);
            
            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void SetFlagReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(100, false);
            for(ulong i = 0; i < 100; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.True(mbf.GetFlag());
        }

        [Fact]
        public void SetFlagExceeedsLength()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(100, false);
            mbf.SetFlag(999999);
            
            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void ResetFlagReturnsFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(100, false);
            for (ulong i = 0; i < 100; i++)
            {
                mbf.ResetFlag(i);
            }

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void ResetFlagExceedsLength()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(3, false);
            mbf.ResetFlag(999999);
            
            Assert.True(mbf.GetFlag());
        }

        [Fact]
        public void ConstructorExceedMaxLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new IIG.BinaryFlag.MultipleBinaryFlag(9999999999999999999, false));
        }

        [Fact]
        public void ConstructorMinLengthRun()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1, false);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => mbf.GetFlag());
        }

        [Fact]
        public void SetFlagExceedsLength()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(99, false);
            for (ulong i = 10; i < 999; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void SetFlag1000ReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);
            for (ulong i = 0; i < 1000; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.True(mbf.GetFlag());
        }

        [Fact]
        public void ResetFlagNotAllReturnsFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(99, true);
            for (ulong i = 0; i < 9; i++)
            {
                mbf.ResetFlag(i);
            }

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void GetFlagReturnsFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            mbf.SetFlag(1);

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void GetFlagRerunsFalseFromStart()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);
            for (ulong i = 1; i < 1000; i++)
            {
                mbf.SetFlag(i);
            }

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void GetFlagWithOnlyOneSetFlagReturnFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);
            mbf.SetFlag(300);

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void OneResetFlagReturnToAllFlagsFalse()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, true);
            mbf.ResetFlag(999);

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void CheckOnlyOneSetFlagOnWholeLength()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf = new IIG.BinaryFlag.MultipleBinaryFlag(1000, false);
            mbf.SetFlag(0);

            Assert.False(mbf.GetFlag());
        }

        [Fact]
        public void CheckForEqualityAlmostSame()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(2, false);
            mbf1.SetFlag(1);

            Assert.False(mbf1.Equals(mbf2));
        }

        [Fact]
        public void CheckForEqualityAlmostSameBigger()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(50000, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(50000, false);
            mbf1.SetFlag(1489);

            Assert.False(mbf1.Equals(mbf2));
        }

        [Fact]
        public void CheckSameWithEqualsReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);

            Assert.True(mbf1.Equals(mbf2));
        }

        [Fact]
        public void CheckSameWithEqualsOnSameReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(5, false);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(5, false);

            Assert.True(mbf1.Equals(mbf2));
        }

        [Fact]
        public void EqualsOnEqualObjectReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(500000, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = new IIG.BinaryFlag.MultipleBinaryFlag(500000, true);

            Assert.True(mbf1.Equals(mbf2));
        }

        [Fact]
        public void EqualsOnSameRefReturnsTrue()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            IIG.BinaryFlag.MultipleBinaryFlag mbf2 = mbf1;

            Assert.True(mbf1.Equals(mbf2));
        }

        [Fact]
        public void Dispose()
        {
            IIG.BinaryFlag.MultipleBinaryFlag mbf1 = new IIG.BinaryFlag.MultipleBinaryFlag(2, true);
            mbf1.Dispose();

            Assert.True(mbf1.GetFlag());
        }
    }
}
