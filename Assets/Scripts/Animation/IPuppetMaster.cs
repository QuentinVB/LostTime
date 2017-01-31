using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public interface IPuppetMaster
{
    CharaAnimCtrl GetAnimCtrl();
    CharaAnimCtrl GetAnimCtrl(string job);
    CharaAnimCtrl GetAnimCtrl(job job);
    CharaAnimCtrl GetAnimCtrl(InputMode inputMode, WalkMode walkmode);
    CharaAnimCtrl GetAnimCtrl(WalkMode walkmode);
}

