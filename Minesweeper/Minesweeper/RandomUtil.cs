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
            // This ensures that one thread does not enter a critical section of code while another thread 
            // is in the critical section. If another thread tries to enter a locked code, it will wait, block, 
            // until the object is released.
            lock(syncLock) { // synchronize
				return getRandom.Next(min, max);
			}
		}
	}
}

