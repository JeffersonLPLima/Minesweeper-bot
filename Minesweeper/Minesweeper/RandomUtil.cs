using System;

namespace Minesweeper{
	public static class RandomUtil{
		private static readonly Random getRandom = new Random();
		private static readonly object syncLock = new object();

        /// <summary>
        /// Get a random number
        /// </summary>
        /// <param name="min"> min limit of the interval </param>
        /// <param name="max"> max limit of the interval </param>
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

