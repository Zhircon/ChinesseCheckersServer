using DataAccess;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    public partial class GameService : IRelationshipMgt
    {
        OperationResult IRelationshipMgt.CreateRelationship(int _idPlayerOwner, int _idPlayerGuest)
        {
            return Logic.RelationshipManager.CreateRelationShip(_idPlayerOwner, _idPlayerGuest);
        }

        OperationResult IRelationshipMgt.DeclarateBadRelationship(int _idPlayerOwner, int _idPlayerGuest)
        {
            return Logic.RelationshipManager.DeclarateBadRelationship(_idPlayerOwner, _idPlayerGuest);
        }

        List<Relationship> IRelationshipMgt.GetRelationships(int _idPlayerOwner)
        {
            return Logic.RelationshipManager.GetRelationships(_idPlayerOwner);
        }
    }
}
