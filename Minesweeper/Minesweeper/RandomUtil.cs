using System;

namespace Minesweeper{
	public static class RandomUtil{
		private static readonly Random getRandom = new Random();
		private static readonly object syncLock = new object();
        /// <summary>
        /// get a random number
        /// </summary>
        /// <param name="min"> buttom limit of the interval </param>
        /// <param name="max"> top-1 limit of the interval </param>
        /// <returns>
        /// a random number between in interval [min,max)
        /// </returns>
        public static int GetRandomNumber(int min, int max){
			lock(syncLock) { // synchronize
				return getRandom.Next(min, max);
			}
		}
	}
}

