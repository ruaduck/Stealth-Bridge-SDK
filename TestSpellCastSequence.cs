using System;
using System.Threading.Tasks;
using StealthBridgeSDK.Skills;
using StealthBridgeSDK.Spells;
using StealthBridgeSDK.Targeting;

class Program
{
    static async Task Main(string[] args)
    {
        var spellClient = new SpellClient();
        var targetingClient = new TargetingClient();
        var skillClient = new SkillClient();

        var getskill = "Magery";
        Console.WriteLine($"=> Getting skill value for '{getskill}'...");
        float skillValue = await skillClient.GetSkillValueAsync(getskill);
       
        var spell = Magery.Curse;
        var cancast = MageryHelper.IsCastableBy(spell,skillValue);
        if (!cancast)
        {
            Console.WriteLine($"❌ You cannot cast '{Magery.GetName(spell)}' with your current skill level ({skillValue}).");
            return;
        }

        var spellName = Magery.GetName(spell);
        Console.WriteLine($"=> Casting '{spellName}'...");

        await spellClient.CastSpellAsync(spellName);
        Console.WriteLine("=> Waiting for target cursor...");
        bool cursorReady = await targetingClient.WaitForTargetAsync(50);
        if (!cursorReady)
        {
            Console.WriteLine("❌ Target cursor did not appear.");
            return;
        }

        Console.WriteLine("=> Cursor appeared. Waiting for user to select...");
        await Task.Delay(3000); // Give time to click in-game
        uint serial = await targetingClient.GetLastSelectedAsync();
        if (serial == 0)
        {
            Console.WriteLine("❌ No target selected.");
            return;
        }
        else
        {
            while (skillValue < 80)
            {
                Console.WriteLine($"✅ Target selected: 0x{serial:X}");
                Console.WriteLine($"=> Recasting '{spellName}' on selected target...");
                await spellClient.CastSpellToObjectAsync(spellName, serial);
                Console.WriteLine($"=> Waiting for the spell to finish casting...");
                await Task.Delay(1000);
                skillValue = await skillClient.GetSkillValueAsync(getskill);
                await Task.Delay(1000);
            }
        }

        Console.WriteLine("✅ Done.");

    }
}