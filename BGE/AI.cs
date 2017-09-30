/* Daniel Crews
 * Daniel Kharlamov
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIGameEngine {
    public class AI {
        public NavigationStrategy navStrat;
        public AttackStrategy attackStrat;
    }


    public abstract class NavigationStrategy {

        public virtual NPCAttemptMovementEvent findPath(int x, int y, int id) {
            Console.WriteLine("No Strategy Defined");

            return new NPCAttemptMovementEvent(id, x, y, x, y);

        }
        
    }

    public class DirectMovement : NavigationStrategy {

        public override NPCAttemptMovementEvent findPath(int x, int y, int id) {
            
            Console.WriteLine("Finding most direct path");
            return new NPCAttemptMovementEvent(id, x, y, x + 5, y);
        }
        
    }

    public class FlexibleMovement : NavigationStrategy {

        public override NPCAttemptMovementEvent findPath(int x, int y, int id) {

            Console.WriteLine("Finding most flexible path");
            return new NPCAttemptMovementEvent(id, x, y, x, y + 5);
        }

    }

    public abstract class AttackStrategy {

        public virtual void attack() {
            Console.WriteLine("No Strategy Defined");
        }

    }

    public class AggressiveStrategy : AttackStrategy {

        public override void attack() {
            Console.WriteLine("Aggressive Strategy in use");
        }

    }

    public class DefensiveStrategy : AttackStrategy {

        public override void attack() {
            Console.WriteLine("Defensive Strategy in use");
        }

    }


}
