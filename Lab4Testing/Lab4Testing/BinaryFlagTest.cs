using Xunit;
using System;
using IIG.FileWorker;
using IIG.BinaryFlag;


namespace Lab4Testing
{
    public class BinaryFlagTest
    {
        [Fact]
        public void WriteFlagFalse()
        {

            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, false);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile1.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile1.txt"));
        }

        [Fact]
        public void WriteFlagLongFalse()
        {

            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, false);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile2.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile2.txt"));
        }

        [Fact]
        public void WriteFlagTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(2, true);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile3.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile3.txt"));
        }

        [Fact]
        public void WriteFlagLongTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, true);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile4.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile4.txt"));
        }

        [Fact]
        public void ResetFlagTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10, true);
            mbf.ResetFlag(2);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile5.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile5.txt"));
        }

        [Fact]
        public void ResetFlagLongTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, true);
            mbf.ResetFlag(2);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile6.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile6.txt"));
        }

        [Fact]
        public void ResetFlagLongPositionTrue()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, true);
            mbf.ResetFlag(20000000);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile7.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile7.txt"));
        }

        [Fact]
        public void ResetFlagFalse()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10, false);
            mbf.SetFlag(3);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile8.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile8.txt"));
        }

        [Fact]
        public void ResetFlagLongFalse()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, false);
            mbf.SetFlag(3);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile9.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile9.txt"));
        }

        [Fact]
        public void ResetFlagLongPositionFalse()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, false);
            mbf.SetFlag(20000000);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile10.txt");

            Assert.Equal(mbf.GetFlag().ToString(), BaseFileWorker.ReadAll(@".\testFile10.txt"));
        }


        [Fact]
        public void ReadLines()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10, false);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile11.txt");

            Assert.Equal(mbf.GetFlag().ToString(), String.Join("", BaseFileWorker.ReadLines(@".\testFile11.txt")));
        }

        [Fact]
        public void ReadLinesSetFlag()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10, false);
            mbf.SetFlag(3);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile12.txt");

            Assert.Equal(mbf.GetFlag().ToString(), String.Join("", BaseFileWorker.ReadLines(@".\testFile12.txt")));
        }

        [Fact]
        public void ReadLinesResetFlag()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10, false);
            mbf.ResetFlag(3);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile13.txt");

            Assert.Equal(mbf.GetFlag().ToString(), String.Join("", BaseFileWorker.ReadLines(@".\testFile13.txt")));
        }

        [Fact]
        public void ReadLinesResetFlagLong()
        {
            MultipleBinaryFlag mbf = new MultipleBinaryFlag(10000000000, false);
            mbf.ResetFlag(2000000);

            BaseFileWorker.Write(mbf.GetFlag().ToString(), @".\testFile14.txt");

            Assert.Equal(mbf.GetFlag().ToString(), String.Join("", BaseFileWorker.ReadLines(@".\testFile14.txt")));
        }
    }
}
