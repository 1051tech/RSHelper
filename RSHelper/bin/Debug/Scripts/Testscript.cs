///<author>LupusOverflo</author>
///<name>RSTest</name>
///<version>5.6</version>

using RSHelperLib;
using System.Threading.Tasks;
using System.Windows.Forms;

public class TestScript:  IRSScript
{
	public async Task Run()
	{
		MessageBox.Show("Success!");
	}
}