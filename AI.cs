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

        public virtual NPCAttemptedMovedEvent findPath(int x, int y, int id) {
            Console.WriteLine("No Strategy Defined");

            return new NPCAttemptedMovedEvent(x, y, id);

        }
        
    }

    public class DirectMovement : NavigationStrategy {

        public override NPCAttemptedMovedEvent findPath(int x, int y, int id) {
            
            Console.WriteLine("Finding most direct path");
            return new NPCAttemptedMovedEvent(x+5, y, id);

        }
        
    }

    public class FlexibleMovement : NavigationStrategy {

        public override NPCAttemptedMovedEvent findPath(int x, int y, int id) {

            Console.WriteLine("Finding most flexible path");
            return new NPCAttemptedMovedEvent(x, y+5, id);
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
