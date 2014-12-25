using System;

namespace Minesweeper{
	public static class RandomUtil{
		private static readonly Random getRandom = new Random();
		private static readonly object syncLock = new object();

		public static int GetRandomNumber(int min, int max){
			lock(syncLock) { // synchronize
				return getRandom.Next(min, max);
			}
		}
	}
}

