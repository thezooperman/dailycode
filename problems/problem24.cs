using System.Collections.Generic;

namespace problems
{
    class Problem24
    {
        /*
          Implement locking in a binary tree. A binary tree node can be locked or unlocked only if all of its descendants or ancestors are not locked.

          Design a binary tree node class with the following methods:

          is_locked, which returns whether the node is locked
          lock, which attempts to lock the node. If it cannot be locked, then it should return false. Otherwise, it should lock it and return true.
          unlock, which unlocks the node. If it cannot be unlocked, then it should return false. Otherwise, it should unlock it and return true.

          You may augment the node to add parent pointers or any other property you would like. You may assume the class is used in a single-threaded program, so there is no need for actual locks or mutexes. Each method should run in O(h), where h is the height of the tree.
        
                         12
                      /      \  
                    10        15
                   /  \      /
                  4   11   13
        */

        internal class LockedBT
        {
            public int Data;
            public LockedBT Parent, Left, Right = null;
            bool locked = false;
            int numOfLockedDescendant = 0;

            public LockedBT(int data, LockedBT parent)
            {
                this.Parent = parent;
                this.Data = data;
            }

            public bool isLocked() => this.locked;

            private bool canLockOrUnlock()
            {
                if (this.numOfLockedDescendant > 0)
                    return false;

                for (LockedBT curr = this.Parent; curr != null; curr = curr.Parent)
                {
                    if (curr.isLocked())
                        return false;
                };

                return true;
            }

            public bool @lock()
            {
                if (this.isLocked())
                    return false;
                if (!this.canLockOrUnlock())
                    return false;

                for (LockedBT curr = this.Parent; curr != null; curr = curr.Parent)
                    curr.numOfLockedDescendant += 1;
                this.locked = true;
                return true;
            }

            public bool unlock()
            {
                if (!this.isLocked())
                    return false;
                if (!this.canLockOrUnlock())
                    return false;

                for (LockedBT curr = this.Parent; curr != null; curr = curr.Parent)
                    curr.numOfLockedDescendant -= 1;
                this.locked = false;
                return true;

            }
        }

        public IEnumerable<bool> problem24()
        {
            LockedBT root = new LockedBT(12, null);
            root.Left = new LockedBT(10, root);
            root.Left.Left = new LockedBT(4, root.Left);
            root.Left.Right = new LockedBT(11, root.Left);

            root.Right = new LockedBT(15, root);
            root.Right.Left = new LockedBT(13, root.Right);

            yield return root.isLocked();

            root.Left.Left.@lock();

            yield return root.isLocked();


        }
    }
}