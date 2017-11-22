using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Collections;

namespace Lab3 {
    class Program {

        static BitArray z;

        const int N = 220;
        const int C = 70;
        /*
        const string myVariant = "00100000111010111011101010010001000010110000010111111001000101101010101110110100100100100010001010011000101010111111100011111010000110110101000010101110011011000100101100000010011010010101110000000000010001010111111010010010011100110100100100011100000010011101010001111001101010110001101010001011000010001001001011101010011010101100110010000110011000110001010111100000010100000110111010101111010001100110101110010100001011111011010010110100111110101011111011001100011010110110010110010001010001001010100110111110100001001000011001100101100101101111001100011001010110000110111010011101110000110011010000111000101111111011011100001011011011101110001100010010011000001101111101000100101111110101011001101111000010101110000110011000111110101101100001101010101100010001011110100010001111110101011110101100101011000001100111001100101110011111110010110011100100111101010110111001001001001110001111001001011110110011111110000010010100111111010100011100001101000001011011111100011111111100111001100010110100001100110011001001110000100001110111000101010101011111101000101101110101100101100010001010111100100100001100111110101010111100000011100101111101110110010011101011001111101001001111100101100000100100010000011001110110111011011011101001100011100010000001001000000111011001110100001110001000001000100110001001100111100110110010011110101001110111110001010010101110110101111100010100010011111100010000010111001100111011101111010011011101000001110111111100010000000101001100011011100111001111011100011110001101110000100100010110111011010111110011101101100100001101101100100111100011100011100000100101000100101101010100111001110100101101111011010111101100001101000111011010111110001010000000101001010000001001100000000100100111001001011010001101100010010100010101100100110100111000010000000101000100000001111100000101010101111000111011001110110111001100110011110001101010100100011111100100101001001001001010111010010001101100011101111100010110011010001001010101001010000010011111010111010111100110111111001110110100100100000101111101111000001010111010110000";

        static int[] L1 = new int[] { 0, 1, 4, 6 };
        static int[] L2 = new int[] { 0, 3 };
        static int[] L3 = new int[] { 0, 1, 2, 3, 5, 7 };
        asdasd
        asdasd
        asdasd
        asdasd
		asdasdasd
		asdasd
        asdasd

        static int L1_len = 30;
        static int L2_len = 31;
        static int L3_len = 32;
        */
            
         //for dummies
         
        const string myVariant = "01010100000100011110010000111010011110110010111111010101111100100000110000011100001001010000000110011100000011001110100110000100011011101000111010001010011100110001011111101010111001011001101001011001110001010101010001111110011001001100110000101000011111011001010101110011010001000000010001010000111100100000001100100001001101000110010100000101001001011000111011110010101110001000000010111110111101110000001010010010011111100000101001011100010001110010010011010111110101011000111000010111010000100000001001010100001111101000010011111011101010011111010111110110111011011000010100010000101001000110001000010100101010111010100100101001110010110011100100011111110000101101110001111111001000010000010001100101111001001101000001011001101001000110101100000000100101100011000010000100100010111111111001011011010010110001011101000001001111011101001110101100011000101101000100000011100100101110011011001101101011101100000001111001010010001001000111110001000001011010110110101010100011000101000111111110001011110001000101100101110101010101010000010010101110110110010110000101100111000111111010100110110101100110001010010011101101101101111100000110000110110101111110011110101001101101100000111110101100000111101101000100001000010001001000001111100011110010101110101010100010100110101001010110100111111110010100110010010111011100001000000001110000000001011111001111101000001001001110111000000001010101010100100000011111100110000011100001011111101001110011100000100111110010001010101100101110110000101111111011101101011000111111000101000010010011110001110010001011011101110010010011011101111000100100111110111110001110010001010101010110000110100010111000111110010010110001101011101010110010011001001111011001001011010001010111001111010000110111111111010001110010000011001110101011110101000100011111011110101100010011111000111100111011110100011101110101000101110111111010101110001110100010111111001110110111010100011001111100000111010100001111111010001010110010111101000110110001011110011100111011000011000000000011011001101100100110010111010110100100011100001100";
        static int[] L1 = new int[] { 0, 3 };
        static int[] L2 = new int[] { 0, 1, 2, 6 };
        static int[] L3 = new int[] { 0, 1, 2, 5 };
        
        static int L1_len = 25;
        static int L2_len = 26;
        static int L3_len = 27;
        
        

        static bool IsValid(BitArray x, BitArray y) {

            for (int i = 0; i < N; i++) {
                if (x.Get(i) == true && y.Get(i) == true && z.Get(i) == false) {
                    return false;
                }
                if (x.Get(i) == false && y.Get(i) == false && z.Get(i) == true) {
                    return false;
                }
            }

            return true;
        }

        static void SieveSequences() {
            Console.WriteLine("Sieving pairs...");
            LFSR.N = N;
            BitArray x = new BitArray(N);
            BitArray y = new BitArray(N);
            StreamReader reader = new StreamReader("x.txt");
            List<UInt32> statesX = new List<uint>();
            while (!reader.EndOfStream) {
                statesX.Add(Convert.ToUInt32(reader.ReadLine()));
            }
            reader.Close();
            reader = new StreamReader("y.txt");
            List<UInt32> statesY = new List<uint>();
            while (!reader.EndOfStream) {
                statesY.Add(Convert.ToUInt32(reader.ReadLine()));
            }
            reader.Close();

            List<Tuple<uint, uint>> acceptablePairs = new List<Tuple<uint, uint>>();
            for (int indexX = 0; indexX < statesX.Count; indexX++) {
                UInt32 maskX = LFSR.GetMaskFromPolynom(L1, L1_len);
                BitArray sequenceX = LFSR.GetSequence(statesX[indexX], maskX, L1_len);
                Parallel.For(0, statesY.Count, (index) => {
                    UInt32 maskY = LFSR.GetMaskFromPolynom(L2, L2_len);
                    BitArray sequenceY = LFSR.GetSequence(statesY[index], maskY, L2_len);

                    if (IsValid(sequenceX, sequenceY)) {
                        Tuple<uint, uint> newPair = new Tuple<uint, uint>(statesX[indexX], statesY[index]);
                        acceptablePairs.Add(newPair);
                        Console.WriteLine("Found acceptable pair! {0} {1}", statesX[indexX], statesY[index]);
                    }
                });
            }
            Console.WriteLine($"Found {acceptablePairs.Count} acceptable pair(s)");
            File.Create("pairs.txt").Close();
            StreamWriter writer = new StreamWriter("pairs.txt");
            foreach (Tuple<uint, uint> pair in acceptablePairs) {
                writer.Write("{0} {1}\n", pair.Item1, pair.Item2);
            }
            writer.Close();
        }

        static void GetControllerSequence(BitArray x, BitArray y) {
            Console.WriteLine("Finding S...");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            LFSR.N = N;
            LFSR.shift = L3_len;
            LFSR.polynomial = L3;
            LFSR.numberOfCoef = L3.Length;
            LFSR.mask = LFSR.GetMaskFromPolynom(L3, L3_len);
            
            List<uint> found = new List<uint>();
            Parallel.For(1, (long)Math.Pow(2, L3_len), (state) => {
                BitArray sequence = LFSR.GetSequence((uint)state);
                if (LFSR.CompareSequences(LFSR.GeffeGenerator(x, y, sequence, N), z)) {
                    Console.WriteLine("Found! {0}", state);
                    found.Add((uint)state);
                }
            });
            File.Create("s.txt").Close();
            StreamWriter writer = new StreamWriter("s.txt");
            foreach (uint state in found) {
                writer.Write("{0}\n", state);
            }
            writer.Close();
            sw.Stop();
            Console.WriteLine("Time elapse on finding s: {0}", sw.Elapsed);
        }

        static int CheckStatistics(BitArray x) {
            if (x.Count != N) {
                Console.WriteLine("x.Count != {0}", N);
                return 0; 
            }
            int count = 0;
            
            for (int i = 0; i < N; i++) {
                count += (x.Get(i) ^ z.Get(i)) ? 1 : 0;
            }
            return count;
        }

        static void TryToCrack() {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            UInt32 mask = LFSR.GetMaskFromPolynom(L1, L1_len);
            LFSR.mask = mask;
            LFSR.polynomial = L1;
            LFSR.numberOfCoef = L1.Length;
            LFSR.N = N;
            LFSR.shift = L1_len;
            Console.WriteLine("Finding x...");
            List<UInt32> x = new List<UInt32>();
            Parallel.For(1, (long)Math.Pow(2, L1_len), (state) => {
                BitArray result = LFSR.GetSequence((UInt32)state);
                if (result != null) {
                    if (CheckStatistics(result) < C) {
                        x.Add((UInt32)state);
                    }
                }
            });
            Console.WriteLine($"Found {x.Count} possible starting states for X");

            File.Create("x.txt").Close();
            StreamWriter writer = new StreamWriter("x.txt");
            foreach (UInt32 xi in x) {
                writer.Write("{0}\n", xi);
            }
            writer.Close();

            sw.Stop();
            Console.WriteLine("Time elapsed on finding X: {0}", sw.Elapsed);
            sw.Restart();
            mask = LFSR.GetMaskFromPolynom(L2, L2_len);
            LFSR.mask = mask;
            LFSR.polynomial = L2;
            LFSR.numberOfCoef = L2.Length;
            LFSR.shift = L2_len;
            Console.WriteLine("Starting finding y...");
            List<UInt32> y = new List<UInt32>();
            Parallel.For(1, (long)Math.Pow(2, L2_len), (state) => {
                BitArray result = LFSR.GetSequence((UInt32)state);
                if (result != null) {
                    if (CheckStatistics(result) < C) {
                        y.Add((UInt32)state);
                    }
                }
            });
            Console.WriteLine($"Found {y.Count} possible starting states for Y");

            sw.Stop();
            Console.WriteLine("Time elapsed on finding Y: {0}", sw.Elapsed);


            File.Create("y.txt").Close();
            writer = new StreamWriter("y.txt");
            foreach (UInt32 yi in y) {
                writer.Write("{0}\n", yi);
            }
            writer.Close();

            Console.WriteLine(sw.Elapsed);
        }

        static void Main(string[] args) {
            LFSR.N = N;
            z = LFSR.StringToBitArray(myVariant, N);
            TryToCrack();
            SieveSequences();
            

            if (File.Exists("pairs.txt")) {
                StreamReader reader = new StreamReader("pairs.txt");
                string[] line = reader.ReadLine().Split(' ');
                uint stateX = Convert.ToUInt32(line[0]);
                uint stateY = Convert.ToUInt32(line[1]);
                GetControllerSequence(
                    LFSR.GetSequence(stateX, LFSR.GetMaskFromPolynom(L1, L1_len), L1_len),
                    LFSR.GetSequence(stateY, LFSR.GetMaskFromPolynom(L2, L2_len), L2_len)
                );
                reader.Close();
                if (File.Exists("s.txt")) {
                    reader = new StreamReader("s.txt");
                    uint stateS = Convert.ToUInt32(reader.ReadLine());
                    if (CheckIsCorrect(stateX, stateY, stateS)) {
                        Console.WriteLine("Cracked!");
                    }
                    else {
                        Console.WriteLine("Not cracked!");
                    }
                    Console.WriteLine("The numbers are:\nstateX = {0}\nstateY = {1}\nstateS = {2}", stateX, stateY, stateS);
                }
                else {
                    Console.WriteLine("Didn't found any candidate for S!");
                }
            }
            
            // for dummies
            //CheckIsCorrect(28058312, 22103952, 3068240);
            // normal
            //CheckIsCorrect(138209955, 141925897, 3143673795);
        }

        static bool CheckIsCorrect(uint x, uint y, uint s) {
            LFSR.N = 2048;
            BitArray sx = LFSR.GetSequence(x, LFSR.GetMaskFromPolynom(L1, L1_len), L1_len);
            BitArray sy = LFSR.GetSequence(y, LFSR.GetMaskFromPolynom(L2, L2_len), L2_len);
            BitArray ss = LFSR.GetSequence(s, LFSR.GetMaskFromPolynom(L3, L3_len), L3_len);
            BitArray sz = LFSR.StringToBitArray(myVariant, 2048);
            return LFSR.CompareSequences(LFSR.GeffeGenerator(sx, sy, ss, 2048), sz);
        }

        static void GenerateMyOwnVariant() {
            uint x = 7492837;
            uint y = 27159342;
            uint s = 105739022;
            BitArray sx = LFSR.GetSequence(x, LFSR.GetMaskFromPolynom(L1, L1_len), L1_len);

            BitArray sy = LFSR.GetSequence(y, LFSR.GetMaskFromPolynom(L2, L2_len), L2_len);

            BitArray ss = LFSR.GetSequence(s, LFSR.GetMaskFromPolynom(L3, L3_len), L3_len);

            File.WriteAllText("result.txt", LFSR.BitArrayToString(LFSR.GeffeGenerator(sx, sy, ss, 2048)));
        }
    }
}
