using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageLevels
{
    class LevelFunctions
    {
        /// <summary>
        /// Creates a level.
        /// </summary>
        /// <param name="levelDoc">Document to create the level.</param>
        /// <param name="levelName">Level name.</param>
        /// <param name="levelElevation">Level elevation.</param>
        /// <returns>Level created.</returns>
        public static Level CreateLevel(Document levelDoc, String levelName, double levelElevation)
        {
            String txDescription = "Create level";
            using (Transaction tx = new Transaction(levelDoc, txDescription))
            {
                try
                {
                    tx.Start();
                    Level newLevel = Level.Create(levelDoc, levelElevation);
                    newLevel.Name = levelName;
                    tx.Commit();
                    MessageBox.Show("Nível criado com sucesso.");
                    return newLevel;
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a level.
        /// </summary>
        /// <param name="levelDoc">Document to create the level.</param>
        /// <param name="levelName">Level name.</param>
        /// <param name="levelElevation">Level elevation.</param>
        /// <param name="txDescription">Transaction description.</param>
        /// <returns>Level created.</returns>
        public static Level CreateLevel(Document levelDoc, String levelName, double levelElevation,
            bool needsTransaction)
        {
            if (needsTransaction)
            {
                using (Transaction tx = new Transaction(levelDoc, "Create level"))
                {
                    try
                    {
                        tx.Start();
                        Level newLevel = Level.Create(levelDoc, levelElevation);
                        newLevel.Name = levelName;
                        tx.Commit();
                        MessageBox.Show("Nível criado com sucesso.", "Criar nível");
                        return newLevel;
                    }
                    catch (Exception ex)
                    {
                        tx.RollBack();
                        MessageBox.Show(ex.Message, "Erro");
                    }
                }
            }
            else
            {
                Level newLevel = Level.Create(levelDoc, levelElevation);
                newLevel.Name = levelName;
                MessageBox.Show("Nível criado com sucesso.", "Criar nível");
                return newLevel;
            }

            return null;
        }

        /// <summary>
        /// Deletes a level.
        /// </summary>
        /// <param name="levelDoc">Document to delete the level.</param>
        /// <param name="level">Level to delete.</param>
        public static void DeleteLevel(Document levelDoc, Level level)
        {
            using (Transaction tx = new Transaction(levelDoc, "Delete level"))
            {
                try
                {
                    tx.Start();
                    levelDoc.Delete(level.Id);
                    tx.Commit();
                    MessageBox.Show("Nível deletado com sucesso.", "Deletar nível");
                }
                catch(Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
        }

        /// <summary>
        /// Deletes levels.
        /// </summary>
        /// <param name="levelDoc">Document to delete the level.</param>
        /// <param name="levels">Levels to delete.</param>
        public static void DeleteLevels(Document levelDoc, List<Level> levels)
        {
            using (Transaction tx = new Transaction(levelDoc, "Delete levels"))
            {
                try
                {
                    tx.Start();
                    levelDoc.Delete((from level in levels select level.Id).ToList());
                    tx.Commit();
                    MessageBox.Show("Níveis deletados com sucesso.", "Deletar níveis");
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
            

        }

        /// <summary> 
        /// Copies a level.
        /// </summary>
        /// <param name="levelDoc">Document to copy the level.</param>
        /// <param name="levelsToCopy">Level to copy.</param>
        /// <returns>List of levels created from copy.</returns>
        public static List<Level> CopyLevels(Document levelDoc, List<Level> levelsToBeCopied)
        {
            List<Level> newLevels = new List<Level>();
            using (Transaction tx = new Transaction(levelDoc, "Copiar nível"))
            {
                try
                {
                    tx.Start();
                    foreach (Level levelToBeCopied in levelsToBeCopied)
                    {
                        Level newLevel = CreateLevel(levelDoc, levelToBeCopied.Name, levelToBeCopied.Elevation,
                             false);
                        newLevels.Add(newLevel);
                    }
                    tx.Commit();
                    MessageBox.Show("Níveis copiados com sucesso.", "Copiar nível");
                    return newLevels;
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
            return null;
        }

        /// <summary> Aligns level
        /// Aligns two levels.
        /// </summary>
        /// <param name="levelToBeAligned">Level to be aligned.</param>
        /// <param name="levelBase">Level base to align levelToBeAligned.</param>
        public static void AlignLevel(Level levelToBeAligned, Level levelBase)
        {
            using (Transaction tx = new Transaction(levelToBeAligned.Document, "Align levels"))
            {
                try
                {
                    tx.Start();
                    levelToBeAligned.Elevation = levelBase.Elevation;
                    tx.Commit();
                    MessageBox.Show("Nível alinhado com sucesso.", "Alinhar nível");
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }

        }

        /// <summary> Aligns levels
        /// Aligns pairs of levels.
        /// </summary>
        /// <param name="levelsToBeAligned">Levels to be aligned.</param>
        /// <param name="levelsBase">Levels base to align levelsToBeAligned.</param>
        public static void AlignLevels(List<Level> levelsToBeAligned, List<Level> levelsBase)
        {
            using (Transaction tx = new Transaction(levelsToBeAligned.First().Document, "Align levels"))
            {
                try
                {
                    tx.Start();
                    for(int i=0; i<levelsToBeAligned.Count; i++)
                    {
                        levelsToBeAligned[i].Elevation = levelsBase[i].Elevation;

                    }
                    tx.Commit();
                    MessageBox.Show("Níveis alinhados com sucesso.", "Alinhar níveis");
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }

        }
    }
}
