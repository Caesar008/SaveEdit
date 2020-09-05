using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibNbt;

namespace SaveEdit
{
    public partial class MoznostiHry : Form
    {
        Form1 form;
        bool nacteno = false, chyba = false;
        int spawnX, spawnY, spawnZ;
        public MoznostiHry(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            try
            {
                if (!form.Prepnuto)
                {
                    if (form.varianta != 5)
                    {
                        seed.Text = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtLong>("RandomSeed").Value.ToString();
                        int diff = 0;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value;
                        else
                            diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value;

                        if (diff != form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                            diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value == 1)
                        {
                            hardcore.Checked = true;
                        }
                        else if (diff == 0)
                        {
                            survival.Checked = true;
                        }
                        else if (diff == 1)
                        {
                            creative.Checked = true;
                        }
                        else if (diff == 2)
                        {
                            adventure.Checked = true;
                        }
                        else if (diff == 3)
                        {
                            spectator.Checked = true;
                        }
                        try
                        {
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("allowCommands").Value == 0)
                                cheaty.Checked = false;
                            else
                                cheaty.Checked = true;
                        }
                        catch
                        {
                            form.save.RootTag.Get<NbtCompound>("Data").Add(new NbtByte("allowCommands", 0));
                            cheaty.Checked = false;
                        }
                        nesmrtelnost.Enabled = true;
                        ztrataItemu.Enabled = true;
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules") == null)
                            form.save.RootTag.Get<NbtCompound>("Data").Add(new NbtCompound("GameRules"));
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("keepInventory") == null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Add(new NbtString("keepInventory", "false"));

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("doDaylightCycle") == null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Add(new NbtString("doDaylightCycle", "true"));

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("doDaylightCycle").Value == "true")
                            denNoc.Checked = true;
                        else
                            denNoc.Checked = false;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("keepInventory").Value == "true")
                            ztrataItemu.Checked = true;
                        else
                            ztrataItemu.Checked = false;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtByte>("Invulnerable") == null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Add(new NbtByte("Invulnerable", 0));

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtByte>("Invulnerable").Value == 1)
                            nesmrtelnost.Checked = true;
                        else
                            nesmrtelnost.Checked = false;

                        hodiny.TextAlign = HorizontalAlignment.Center;
                        hodiny.Value = (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtLong>("DayTime").Value / 1000 + 6) % 24;
                        double cas = (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtLong>("DayTime").Value % 1000) / 1000d;
                        minuty.Value = (int)(cas * 60d);
                        minuty.TextAlign = HorizontalAlignment.Center;

                        zivot.Maximum = short.MaxValue;
                        zivot.Minimum = 0;
                        zivot.TextAlign = HorizontalAlignment.Center;
                        if(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtTag>("Health").TagType == NbtTagType.Short)
                            zivot.Value = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtShort>("Health").Value;
                        else
                            zivot.Value = (decimal)form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtFloat>("Health").Value;
                        maxZivot.Maximum = short.MaxValue;
                        maxZivot.Minimum = 0;
                        maxZivot.TextAlign = HorizontalAlignment.Center;

                        spawnX = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnX").Value;
                        x.Text = spawnX.ToString();
                        spawnY = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnY").Value;
                        y.Text = spawnY.ToString();
                        spawnZ = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnZ").Value;
                        z.Text = spawnZ.ToString();

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("DifficultyLocked") != null)
                        {
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("DifficultyLocked").Value == 0)
                                zamceniObtiznosti.Checked = false;
                            else
                                zamceniObtiznosti.Checked = true;
                        }
                        else
                            zamceniObtiznosti.Enabled = false;

                        try
                        {
                            foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                            {
                                if (c.Get<NbtString>("Name").Value == "generic.maxHealth")
                                    maxZivot.Value = (int)(c.Get<NbtDouble>("Base").Value);
                            }

                            utok.Maximum = decimal.MaxValue;
                            utok.Minimum = 0;
                            utok.TextAlign = HorizontalAlignment.Center;
                            foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                            {
                                if (c.Get<NbtString>("Name").Value == "generic.attackDamage")
                                    utok.Value = (int)(c.Get<NbtDouble>("Base").Value);
                            }

                            odrazeni.TextAlign = HorizontalAlignment.Center;
                            odrazeni.Maximum = decimal.MaxValue;
                            odrazeni.Minimum = 0;
                            foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                            {
                                if (c.Get<NbtString>("Name").Value == "generic.knockbackResistance")
                                    odrazeni.Value = (int)(c.Get<NbtDouble>("Base").Value);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Save byl hrán naposled ve verzi Minecraftu před 1.6.\nNebudeš moci využít některé možnosti.");
                            maxZivot.Enabled = false;
                            utok.Enabled = false;
                            odrazeni.Enabled = false;
                            button2.Enabled = false;
                            button3.Enabled = false;
                        }
                    }
                    else
                    {
                        if (form.save.RootTag.Get<NbtInt>("RandomSeed") != null)
                            seed.Text = form.save.RootTag.Get<NbtInt>("RandomSeed").Value.ToString();
                        else
                            kopirovatSeed.Enabled = false;

                        if (form.save.RootTag.Get<NbtByte>("hardcore") != null)
                        {
                            int diff = 0;
                            if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                                diff = form.save.RootTag.Get<NbtByte>("Difficulty").Value;
                            else
                                diff = form.save.RootTag.Get<NbtInt>("GameType").Value;

                            if (form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType") != null)
                                if (diff != form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                                    diff = form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;


                            if (form.save.RootTag.Get<NbtByte>("hardcore").Value == 1)
                            {
                                hardcore.Checked = true;
                            }
                            else if (diff == 0)
                            {
                                survival.Checked = true;
                            }
                            else if (diff == 1)
                            {
                                creative.Checked = true;
                            }
                            else if (diff == 2)
                            {
                                adventure.Checked = true;
                            }
                            else if (diff == 3)
                            {
                                spectator.Checked = true;
                            }
                        }
                        else
                        {
                            hardcore.Enabled = false;
                            survival.Enabled = false;
                            creative.Enabled = false;
                            adventure.Enabled = false;
                            spectator.Enabled = false;
                        }


                        try
                        {
                            if (form.save.RootTag.Get<NbtByte>("allowCommands").Value == 0)
                                cheaty.Checked = false;
                            else
                                cheaty.Checked = true;
                        }
                        catch
                        {
                            form.save.RootTag.Add(new NbtByte("allowCommands", 0));
                            cheaty.Checked = false;
                        }
                        ztrataItemu.Enabled = false;

                        if (form.save.RootTag.Get<NbtByte>("Invulnerable").Value == 1)
                            nesmrtelnost.Checked = true;
                        else
                            nesmrtelnost.Checked = false;
                        ztrataItemu.Checked = false;
                    }
                }

            }
            catch { 
                MessageBox.Show("Save je ze starší verze MC než 1.3.\nProsím, ulož tento save v novějším MC a načti tento save znovu.");
                chyba = true;
            }
            nacteno = true;
        }

        private void survival_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                if(!chyba)
                    form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value;

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType") != null)
                        if (diff != form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                            diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;


                    if (diff != 0)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value = 0;
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value = 0;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 0;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value = 0;
                    }
                }
                else
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;


                    if (diff != 0)
                    {
                        form.save.RootTag.Get<NbtInt>("GameType").Value = 0;
                        if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtByte>("Difficulty").Value = 0;
                        form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 0;
                        form.save.RootTag.Get<NbtByte>("hardcore").Value = 0;
                    }
                }
            }
        }

        private void creative_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 1)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value = 1;
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value = 1;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 1;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value = 0;
                    }
                }
                else
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 1)
                    {
                        form.save.RootTag.Get<NbtInt>("GameType").Value = 1;
                        if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtByte>("Difficulty").Value = 1;
                        form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 1;
                        form.save.RootTag.Get<NbtByte>("hardcore").Value = 0;
                    }
                }
            }
        }

        private void adventure_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 2)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value = 2;
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value = 2;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 2;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value = 0;
                    }
                }
                else
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 2)
                    {
                        form.save.RootTag.Get<NbtInt>("GameType").Value = 2;
                        if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtByte>("Difficulty").Value = 2;
                        form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 2;
                        form.save.RootTag.Get<NbtByte>("hardcore").Value = 0;
                    }
                }
            }
        }

        private void hardcore_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value != 1)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value = 0; 
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value = 0;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 0;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value = 1;
                    }
                }
                else
                {
                    if (form.save.RootTag.Get<NbtByte>("hardcore").Value != 1)
                    {
                        form.save.RootTag.Get<NbtInt>("GameType").Value = 0;
                        if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtByte>("Difficulty").Value = 0;
                        form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 0;
                        form.save.RootTag.Get<NbtByte>("hardcore").Value = 1;
                    }
                }
            }
        }

        private void spectator_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 3)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("GameType").Value = 3;
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("Difficulty").Value = 3;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 3;
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("hardcore").Value = 0;
                    }
                }
                else
                {
                    int diff = 0;

                    if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                        diff = form.save.RootTag.Get<NbtByte>("Difficulty").Value;
                    else
                        diff = form.save.RootTag.Get<NbtInt>("GameType").Value;
                    if (diff != form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value)
                        diff = form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value;

                    if (diff != 3)
                    {
                        form.save.RootTag.Get<NbtInt>("GameType").Value = 3;
                        if (form.save.RootTag.Get<NbtByte>("Difficulty") != null)
                            form.save.RootTag.Get<NbtByte>("Difficulty").Value = 3;
                        form.save.RootTag.Get<NbtCompound>("Player").Get<NbtInt>("playerGameType").Value = 3;
                        form.save.RootTag.Get<NbtByte>("hardcore").Value = 0;
                    }
                }
            }
        }

        private void cheaty_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (cheaty.Checked)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("allowCommands").Value = 1;
                    }
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("allowCommands").Value = 0;
                }
                else
                {
                    if (cheaty.Checked)
                    {
                        form.save.RootTag.Get<NbtByte>("allowCommands").Value = 0;
                    }
                    else
                        form.save.RootTag.Get<NbtByte>("allowCommands").Value = 0;
                }
            }
        }

        private void kopirovatSeed_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(seed.Text);
        }

        private void nesmrtelnost_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (nesmrtelnost.Checked)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtByte>("Invulnerable").Value = 1;
                    }
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtByte>("Invulnerable").Value = 0;
                }
            }
        }

        private void ztrataItemu_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (ztrataItemu.Checked)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("keepInventory").Value = "true";
                    }
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("keepInventory").Value = "false";
                }
            }
        }

        private void denNoc_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (denNoc.Checked)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("doDaylightCycle").Value = "true";
                    }
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("GameRules").Get<NbtString>("doDaylightCycle").Value = "false";
                }
            }
        }

        private void hodiny_ValueChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtLong>("DayTime").Value = (long)((hodiny.Value * 1000 - 6000) + (minuty.Value / 60m * 1000));
                }
            }
        }

        private void zivot_ValueChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtTag>("Health").TagType == NbtTagType.Short)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtShort>("Health").Value = (short)zivot.Value;
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtFloat>("Health").Value = (float)zivot.Value;
                    try
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtFloat>("HealF").Value = (short)zivot.Value;
                    }
                    catch { }
                }
                if (zivot.Value > maxZivot.Value)
                    maxZivot.Value = zivot.Value;
            }
        }

        private void maxZivot_ValueChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    try
                    {
                        foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                        {
                            if (c.Get<NbtString>("Name").Value == "generic.maxHealth")
                                c.Get<NbtDouble>("Base").Value = (double)maxZivot.Value;
                        }
                    }
                    catch { }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zivot.Value = 20;
            maxZivot.Value = 20;
        }

        private void utok_ValueChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                    {
                        if (c.Get<NbtString>("Name").Value == "generic.attackDamage")
                            c.Get<NbtDouble>("Base").Value = (double)utok.Value;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            utok.Value = 1;
        }

        private void odrazeni_ValueChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Attributes"))
                    {
                        if (c.Get<NbtString>("Name").Value == "generic.knockbackResistance")
                            c.Get<NbtDouble>("Base").Value = (double)odrazeni.Value;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            odrazeni.Value = 0;
        }

        private void MoznostiHry_Load(object sender, EventArgs e)
        {
            if (chyba)
                Close();
        }

        private void x_TextChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
               if (form.varianta != 5)
                {
                    int.TryParse(x.Text, out spawnX);
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnX").Value = spawnX;
                    x.Text = spawnX.ToString();
                }
            }
        }

        private void y_TextChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int.TryParse(y.Text, out spawnY);
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnY").Value = spawnY;
                    y.Text = spawnY.ToString();
                }
            }
        }

        private void z_TextChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    int.TryParse(z.Text, out spawnZ);
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtInt>("SpawnZ").Value = spawnZ;
                    z.Text = spawnZ.ToString();
                }
            }
        }

        private void zamceniObtiznosti_CheckedChanged(object sender, EventArgs e)
        {
            if (nacteno)
            {
                form.NeulozenoMetoda();
                if (form.varianta != 5)
                {
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtByte>("DifficultyLocked").Value = (zamceniObtiznosti.Checked ? (byte)1 : (byte)0);
                }
            }
        }

        
    }
}
