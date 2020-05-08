using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace Battleships.Model
{
    public class AIEasyPlayer : AIPlayer
    {

        public AIEasyPlayer(BattleShipsGame controller) : base(controller)
        {
            
        }

        protected override void GenerateCoords(ref int row, ref int column)
        {
            do
            {
                SearchCoords(ref row, ref column);
            }
            while ((row < 0 || column < 0 || row >= EnemyGrid.Height || column >= EnemyGrid.Width || EnemyGrid.Item(row, column) != TileView.Sea)); // while inside the grid and not a sea tile do the search
        }

        /// <summary>
        /// SearchCoords will randomly generate shots within the grid as long as its not hit that tile already
        /// </summary>
        /// <param name="row">the generated row</param>
        /// <param name="column">the generated column</param>
        private void SearchCoords(ref int row, ref int column)
        {
            row = _Random.Next(0, EnemyGrid.Height);
            column = _Random.Next(0, EnemyGrid.Width);
        }

        protected override void ProcessShot(int row, int col, AttackResult result)
        {
            if (result.Value == ResultOfAttack.ShotAlready)
                throw new ApplicationException("Error in AI");
        }
    }
}
