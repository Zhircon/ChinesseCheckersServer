using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public static class RelationshipManager
    {
        public static List<DataAccess.Relationship> GetRelationships(int _idPlayer)
        {
            List<DataAccess.Relationship> relationships;
            using (var _context= new DataAccess.ChinesseCheckersDBEntities())
            {
                relationships = _context.RelationshipSet.Where(r => r.idOwner.Equals(_idPlayer)).ToList();
            }
            return relationships;
        }
        public static OperationResult CreateRelationShip(int _idOwner,int _idGuest)
        {
            OperationResult operationResult = OperationResult.Unknown;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                var relationShip = new DataAccess.Relationship 
                {
                    idOwner = _idOwner,
                    idGuest = _idGuest
                };
                var invertedRelationShip = new DataAccess.Relationship
                {
                    idOwner = _idGuest,
                    idGuest = _idOwner
                };
                DataAccess.Relationship searchedRelationShip;
                try
                {
                    searchedRelationShip = _context.RelationshipSet.Where(r => r.idOwner.Equals(_idOwner) && r.idGuest.Equals(_idGuest)).FirstOrDefault();
                    if (searchedRelationShip==null)
                    {
                        _context.RelationshipSet.Add(relationShip);
                        _context.RelationshipSet.Add(invertedRelationShip);
                        _context.SaveChanges();
                        operationResult = OperationResult.Sucessfull;
                    }else { operationResult = OperationResult.Failed; }
                    
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    operationResult = OperationResult.ConnectionLost;
                }
            }
            return operationResult;
        }
        public static OperationResult DeclarateBadRelationship (int _idOwner,int _idGuest)
        {
            OperationResult operationResult = OperationResult.Unknown;
            using (var _context = new DataAccess.ChinesseCheckersDBEntities())
            {
                try
                {
                    var relationship=_context.RelationshipSet.Where(r => r.idOwner.Equals(_idOwner) && r.idGuest.Equals(_idGuest)).FirstOrDefault();
                    var invertedRelationship=_context.RelationshipSet.Where(r => r.idOwner.Equals(_idGuest) && r.idGuest.Equals(_idOwner)).FirstOrDefault();
                    relationship.IsBadRelation = true;
                    invertedRelationship.IsBadRelation = true;
                    _context.SaveChanges();
                    operationResult = OperationResult.Sucessfull;
                }
                catch (System.Data.Entity.Core.EntityException)
                {
                    operationResult = OperationResult.Failed;
                }
            }
            return operationResult;
        }
    }
}
