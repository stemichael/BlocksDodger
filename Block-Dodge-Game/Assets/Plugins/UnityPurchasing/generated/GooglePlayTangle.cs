#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("TlLc9i4wx22rzJir1jZw+Hw/coHqt9sgNhFk7qmtew6kQu5tQfdDXte132VIiniQ8zmPNWuKZnGiwmA0P/PIDLO0LqbPEiMRLhhB0Oa9NoAVB5Xvx6hqh8ZOBaqMap2xZYQcZ8kehrZzqQucFdYN2AO1K6SKj/38ZjmPMgSGoxDzlF4e8cowgLa45sHsXt3+7NHa1fZalFor0d3d3dnc317d09zsXt3W3l7d3dxF+ho+Jzh/bCPhenBiCWMl5YMj5ekwCtTOU0KmGHCxmEom1BUh4Ad5/3Rlonbz4UQSBQQWsS2OQto+NuXMQIW35iTpLlAaE6U2Vh8u/AOPoYsoCKAR7TAMTmw8Oe2X9DQL9SGU+26EtIKWiY4+uZ8cjZdsK97f3dzd");
        private static int[] order = new int[] { 5,10,4,9,13,8,11,8,10,11,10,13,12,13,14 };
        private static int key = 220;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
