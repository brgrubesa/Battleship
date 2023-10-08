using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }
    public class Gunnery : INextTarget
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            enemyGrid = new EnemyGrid(rows, columns);
            eliminator = new SquareEliminator(rows, columns);
            shipsToShoot = new List<int>(shipLengths);
            CurrentTactics = ShootingTactics.Random;
            currentShootingTactics = new RandomShooting(enemyGrid, shipsToShoot[0]);
        }

        private EnemyGrid enemyGrid;
        private List<int> shipsToShoot;
        private INextTarget currentShootingTactics;
        private Square lastTarget = new Square(0,0);
        private List<Square> squaresHit = new List<Square>();
        private SquareEliminator eliminator;
        public ShootingTactics CurrentTactics { get; private set; }


        public Square NextTarget()
        {
            lastTarget = currentShootingTactics.NextTarget();
            return lastTarget;
        }

        public void ProcessShootingResult(HitResult hitResult)
        {
            
            switch (hitResult)
            {
                case HitResult.Missed:
                    LogHitResult(hitResult);
                    return;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    LogHitResult(hitResult);
                    if (CurrentTactics == ShootingTactics.Inline)
                        return;
                    break;
                case HitResult.Sunken:
                    LogHitResult(hitResult);
                    break;
            }
            ChangeCurrentTactics(hitResult);
        }

        private void ChangeCurrentTactics(HitResult hitResult)
        {
            if(hitResult == HitResult.Sunken)
            {
                ChangeToRandomTactics();
                squaresHit.Clear();
            }
            else if (CurrentTactics == ShootingTactics.Random)
            {
                ChangeToSurroundingTactics();
            }
            else
            {
                ChangeToInlineTactics();
            }
        }

        private void ChangeToInlineTactics()
        {
            CurrentTactics = ShootingTactics.Inline;
            currentShootingTactics = new InlineShooting(enemyGrid, squaresHit, shipsToShoot[0]);
        }

        private void ChangeToSurroundingTactics()
        {
            CurrentTactics = ShootingTactics.Surrounding;
            currentShootingTactics = new SurroundingShooting(enemyGrid, lastTarget, shipsToShoot[0]);
        }

        private void ChangeToRandomTactics()
        {
            CurrentTactics = ShootingTactics.Random;
            currentShootingTactics = new RandomShooting(enemyGrid, shipsToShoot[0]);
        }

        private void LogHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    enemyGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;
                case HitResult.Hit:
                    enemyGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;
                case HitResult.Sunken:
                    squaresHit.Sort((s1, s2) => s1.Row + s1.Column - s2.Row - s2.Column);
                    var toEliminate = eliminator.ToEliminate(squaresHit);
                    foreach(Square square in toEliminate)
                    {
                        square.ChangeState(SquareState.Eliminated);
                    }
                    enemyGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Sunken);
                    shipsToShoot.Remove(squaresHit.Count);
                    break;
            }
        }
    }
}
