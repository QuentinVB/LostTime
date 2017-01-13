using Zenject;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

interface IpathFindingEntity
{
    // par vivan
}

class Pnjs : MonoBehaviour
{
    List<pnj> blop;

    Pnjs()
    {
        blop = new List<pnj>();
        blop.Add(new pnj("Fleuriste", 1));
        blop.Add(new pnj("Forgeron", 1));
        blop.Add(new pnj());
    }

    class pnj
    {
        public string namepnj;
        public int Idpnj;

        public pnj(string v, int id)
        {
            this.namepnj = v;
            this.Idpnj = id;
        }
        public pnj()
        {
            this.namepnj = "";
            this.Idpnj = -1;
        }
    }

    public class EntitysInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Pnjs toto = new Pnjs();
            foreach (pnj s in toto.blop)
                EntityInstaller.Install(Container);
        }
    }

    public class EntityInstaller : Installer<EntityInstaller>
    {
        public override void InstallBindings()
        {
            Pnjs toto = new Pnjs();
            foreach (pnj s in toto.blop)
                Container.Bind<string>().FromInstance(s.namepnj); // verifier difference entre assingle ,transcient, ascached
            Container.Bind<IpositionEntity>();
            Container.Bind<IinteractionWithUser>(); // done 
            Container.Bind<IbehaviourEntity>(); // done
                                                //Container.Bind<IpathFindingEntity>().FromInstance(new pathFindingEntity());
            Container.Bind<Entity>();
        }
    }
}



public class Entity : MonoBehaviour
{
    IpositionEntity positionEntity;
    IbehaviourEntity behaviourEntity;
    IpathFindingEntity pathFindingEntity;
    IinteractionWithUser interactionWithUser;

    // Entity se qui peut ce deplacer + interagir + comportement
    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IpathFindingEntity _pathFindingEntity, IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = _interactionWithUser;

        this.transform.position = positionEntity.getPosition();

    }
    //Entity se qui peut ce deplacer + comportement
    Entity(IpositionEntity _positionEntity,
        IpathFindingEntity _pathFindingEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = _pathFindingEntity;
        interactionWithUser = null;

        this.transform.position = positionEntity.getPosition();
    }

    Entity(IpositionEntity _positionEntity, IbehaviourEntity _behaviourEntity,
        IinteractionWithUser _interactionWithUser)
    {
        positionEntity = _positionEntity;
        behaviourEntity = _behaviourEntity;
        pathFindingEntity = null;
        interactionWithUser = _interactionWithUser;

        this.transform.position = positionEntity.getPosition();
    }

    Entity(IpositionEntity _positionEntity)
    {
        positionEntity = _positionEntity;
        behaviourEntity = null;
        pathFindingEntity = null;
        interactionWithUser = null;

        this.transform.position = positionEntity.getPosition();
    }
}
