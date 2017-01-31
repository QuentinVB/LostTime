using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class PuppetMaster : IPuppetMaster
{
    public CharaAnimCtrl GetAnimCtrl()
    {
        return new CharaAnimCtrl(InputMode.byTransform, WalkMode.idle);
    }
    public CharaAnimCtrl GetAnimCtrl(job job)
    {
        return new CharaAnimCtrl(InputMode.byTransform, WalkMode.walking);
    }
    public CharaAnimCtrl GetAnimCtrl(string job)
    {
        return new CharaAnimCtrl(InputMode.byTransform, WalkMode.walking);
    }
    public CharaAnimCtrl GetAnimCtrl(WalkMode walkmode)
    {
        return new CharaAnimCtrl(InputMode.byTransform, walkmode);
    }
    public CharaAnimCtrl GetAnimCtrl(InputMode inputMode, WalkMode walkmode)
    {
        return new CharaAnimCtrl(inputMode, walkmode);
    }
   
}
//ouais pas folichon mais ça fait la blague

