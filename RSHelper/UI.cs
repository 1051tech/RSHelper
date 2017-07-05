using CSScriptLibrary;
using RSHelperLib;
using RSHelperLib.Input;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RSHelperUI
{
    public partial class UI : Form
    {
        private static IScript currentScript;
        private static ConcurrentDictionary<Guid, ScriptObj> scriptDict = new ConcurrentDictionary<Guid, ScriptObj>();

        public UI()
        {
            LoadScriptSelection();
            InitializeComponent();
            foreach (var script in scriptDict.Values)
            {
                var lvi = new ListViewItem(script.UID.ToString());
                lvi.SubItems.Add(script.Author);
                lvi.SubItems.Add(script.Name);
                lvi.SubItems.Add(script.Version);
                cLvScripts.Items.Add(lvi);
            }
        }

        private void LoadScriptSelection()
        {
            var scriptDir = Path.Combine(Environment.CurrentDirectory, "scripts");
            var scripts = Directory.EnumerateFiles(scriptDir).ToList();
            var result = Parallel.ForEach(scripts, (script) =>
            {
                var scriptObj = new ScriptObj(script);
                scriptDict.TryAdd(scriptObj.UID, scriptObj);
            });
            while (!result.IsCompleted)
                Thread.Sleep(20);
        }

        private async void cLvScripts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var uid = Guid.Parse(e.Item.Text);
            ScriptObj scriptObj;
            scriptDict.TryGetValue(uid, out scriptObj);

            CSScript.Evaluator.ReferenceDomainAssemblies();
            currentScript = await CSScript.Evaluator.LoadCodeAsync<IScript>(scriptObj.GetCode(), null);
            Thread scriptThread = null;
            var result = Task.Factory.StartNew(async () =>
            {
                scriptThread = Thread.CurrentThread;
                await currentScript.Run();
            });

            await RSKeyboard.WaitForKeyPress(Key.Escape);
            try { scriptThread.Interrupt(); }
            catch (ThreadInterruptedException) { }
        }
    }
}
