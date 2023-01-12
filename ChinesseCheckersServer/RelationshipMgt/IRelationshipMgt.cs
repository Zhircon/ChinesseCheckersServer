using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChinesseCheckersServer
{
    [ServiceContract]
    interface IRelationshipMgt
    {
        [OperationContract]
        Logic.OperationResult CreateRelationship(int _idPlayerOwner, int _idPlayerGuest);
        [OperationContract]
        List<DataAccess.Relationship> GetRelationships(int _idPlayerOwner);
        [OperationContract]
        Logic.OperationResult DeclarateBadRelationship(int _idPlayerOwner, int _idPlayerGuest);
    }
}
