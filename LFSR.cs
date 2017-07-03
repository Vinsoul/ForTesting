using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab3 {
    public class LFSR {

        public static UInt32 mask;
        public static int shift;
        public static int N;
        public static int[] polynomial;
        public static int numberOfCoef;
		
        public static UInt32 BitsCount(UInt32 i) {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return ((((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24) % 2;
        }

        public static BitArray GetSequence(UInt32 state, UInt32 Mask, int Shift) {
            UInt32 currentState = state;

            BitArray bitArray = new BitArray(N);

            for (int i = 0; i < N; i++) {
                bitArray.Set(i, ((currentState >> (Shift-1)) & 1) == 1);

                UInt32 count = BitsCount(currentState & mask);
                currentState = (currentState << 1) ^ count;
            }

            return bitArray;
        }

        public static BitArray GetSequence(UInt32 state) {
            UInt32 currentState = state;

            BitArray bitArray = new BitArray(N);
            
            for (int i = 0; i < N; i++) {
                bitArray.Set(i, ((currentState >> (shift-1)) & 1) == 1);

                UInt32 count = BitsCount(currentState & mask);
                currentState = (currentState << 1) ^ count;
            }

            return bitArray;
        }

        public static UInt32 GetMaskFromPolynom(int[] coeffitientIndexes, int length) {
            UInt32 result = 0;
            UInt32 bit = ((UInt32)1 << 31);
            foreach (int shift in coeffitientIndexes) {
                result = result | (bit >> shift);
            }
            result = result >> (32 - length);
            return result;
        }

        public static string BitArrayToString(BitArray a) {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Count; i++) {
                sb.Append((a.Get(i) == true) ? 1 : 0);
            }
            return sb.ToString();
        }

        public static BitArray StringToBitArray(string s, int num) {
            if (s.Length < num) {
                Console.WriteLine("StringToBitArray Error!");
                return null;
            }

            BitArray result = new BitArray(num);
            for (int i = 0; i < num; i++) {
                result.Set(i, (s[i] == '1'));
            }
            return result;
        }

        public static BitArray GeffeGenerator(BitArray x, BitArray y, BitArray s, int N) {
            int count = x.Count;
            if (y.Count != count || s.Count != count) {
                Console.WriteLine("GeffeGenerator Error: parameters 'x', 'y' and 's' have different lengths! {0} {1} {2}", x.Count, y.Count, s.Count);
                return null;
            }
            BitArray result = new BitArray(N);
            for (int i = 0; i < N; i++) {
                result.Set(i, 
                    s.Get(i) ? x.Get(i) : y.Get(i)
                    );
            }
            return result;
        }

        public static bool CompareSequences(BitArray s, BitArray z) {
            if (s.Count != z.Count) {
                Console.WriteLine("CompareSequences Error: parameters 's' and 'z' have different length! {0} {1}", s.Count, z.Count);
                return false;
            }
            BitArray result = s.Xor(z);
            for (int i = 0; i < N; i++) {
                if (result.Get(i) != false) {
                    return false;
                }
            }
            return true;
        }
    }
}
