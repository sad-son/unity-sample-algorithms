using NUnit.Framework;

namespace Tests
{
    public class MergeSortedArrayTest
    {
        [Test]
        public void TestCase1()
        {
            var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
            var output = new[] { 1, 2, 2, 3, 5, 6 };
            Merge(nums1, 3, new[] { 2, 5, 6 }, 3);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase2()
        {
            var nums1 = new[] { 1 };
            var nums2 = new int[0];
            var output = new[] { 1 };
            Merge(nums1, 1, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase3()
        {
            var nums1 = new[] { 0 };
            var nums2 = new[] { 1 };
            var output = new[] { 1 };
            Merge(nums1, 0, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }


        //my cases

        [Test]
        public void TestCase4()
        {
            var nums1 = new[] { 2, 3, 7, 0, 0, 0 };
            var nums2 = new[] { 2, 5, 6 };
            var output = new[] { 2, 2, 3, 5, 6, 7 };
            Merge(nums1, 3, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase5()
        {
            var nums1 = new[] { 2, 3, 7, 0, 0, 0, 0, 0 };
            var nums2 = new[] { 12, 15, 16, 18, 22 };
            var output = new[] { 2, 3, 7, 12, 15, 16, 18, 22 };
            Merge(nums1, 3, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase6()
        {
            var nums1 = new[] { 2, 12, 18, 0, 0, 0, 0, 0 };
            var nums2 = new[] { 3, 7, 15, 16, 22 };
            var output = new[] { 2, 3, 7, 12, 15, 16, 18, 22 };
            Merge(nums1, 3, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase7()
        {
            var nums1 = new int[0];
            var nums2 = new int[0];
            var output = new int[0];
            Merge(nums1, 0, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        [Test]
        public void TestCase8()
        {
            var nums1 = new[] { 2, 12, 18, 55, 0, 0, 0, 0, 0 };
            var nums2 = new[] { 3, 7, 15, 16, 22 };
            var output = new[] { 2, 3, 7, 12, 15, 16, 18, 22, 55 };
            Merge(nums1, 4, nums2, nums2.Length);
            Assert.AreEqual(nums1, output);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (nums1[i] > nums2[j])
                    {
                        (nums1[i], nums2[j]) = (nums2[j], nums1[i]);
                    }
                }
            }

            for (int i = m, j = 0; i < nums1.Length; i++, j++)
            {
                nums1[i] = nums2[j];
            }
        }

        public void Merge2(int[] nums1, int m, int[] nums2, int n) 
        {
            int a = m - 1;
            int b = n - 1;
            for (int i = nums1.Length - 1; i >= 0; i--)
            {
                if (a >= 0 && (b < 0 || nums1[a] >= nums2[b]))
                {
                    nums1[i] = nums1[a];
                    a--;
                }
                else
                {
                    nums1[i] = nums2[b];
                    b--;
                }
            }
        }
    }
}