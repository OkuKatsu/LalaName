using System;
using Dalamud.Game.Gui.NamePlate;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalamud.Game.ClientState.Objects.Enums;

namespace LalaName
{
    internal class Nameplate
    {
        public Nameplate()
        {
            Service.NamePlateGui.OnNamePlateUpdate += static (context, handlers) =>
            {
                foreach (var handler in handlers)
                {
                    if (handler.NamePlateKind == NamePlateKind.PlayerCharacter)
                    {
                        unsafe
                        {
                            if (handler.PlayerCharacter == null) return;
                            var customizeByte = handler.PlayerCharacter.Customize;

                            if (customizeByte[(int)CustomizeIndex.Race] == (byte)Constant.Race.LALAFELL)
                            {
                                if (customizeByte[(int)CustomizeIndex.Gender] == (byte)Constant.Gender.MALE)
                                {
                                    handler.NameParts.Text = $"{handler.Name} ♂";
                                }
                                else if (customizeByte[(int)CustomizeIndex.Gender] == (byte)Constant.Gender.FEMALE)
                                {
                                    handler.NameParts.Text = $"{handler.Name} ♀";
                                }
                            }
                        }
                    }
                }
            };
        }

        public void Dispose() { }
    }
}
