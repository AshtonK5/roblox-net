using RobloxEngine;

class ShooterGame : Game
{
     public override void OnGameplayStarted()
     {
          Luau.Print("Gameplay Started!");

          WeaponViewController weaponViewController = new WeaponViewController();
          weaponViewController.OnEntityStart();
     }

     public override void OnGameplayEnded()
     {

     }

     public override void OnGameplayPhysicsTick(float deltaTime)
     {

     }

     public override void OnServiceAdded(Service robloxService)
     {

     }
}

public abstract class Entity
{
     protected Motor6D CreateJoint(Instance p1, Instance p2)
     {
          var joint = Instance.New<Motor6D>(p1);
          joint.Name = p2.Name;
          joint.P0 = p2;
          joint.P1 = p1;
          return joint;
     }

     public virtual void OnEntityStart() { }
}

class WeaponViewController : Entity
{
     public Model RootModel { get; private set; }
     public Part RootPart { get; private set; }
     public WeaponViewArms ViewArms { get; private set; }

     public Motor6D RightArmJoint { get; private set; }
     public Motor6D LeftArmJoint { get; private set; }

     public override void OnEntityStart()
     {
          RootModel = Instance.New<Model>();
          RootPart = Instance.New<Part>();

          ViewArms = new WeaponViewArms();

          RightArmJoint = CreateJoint(ViewArms.RightArm, RootPart);
          LeftArmJoint = CreateJoint(ViewArms.LeftArm, RootPart);
     }
}

struct WeaponViewArms
{
     public Part RightArm;
     public Part LeftArm;

     public WeaponViewArms()
     {
          RightArm = Instance.New<Part>();
          LeftArm = Instance.New<Part>();
     }
}
