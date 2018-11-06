using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cancellation
{
    public partial class CancelLongRunning : Form
    {
        private CancellationTokenSource TokenSource { get; set; }

        private CancellationToken Token { get; set; }

        public CancelLongRunning()
        {
            InitializeComponent();

            TokenSource = new CancellationTokenSource();
            Token = TokenSource.Token;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await LongRunningOperation();
            }
            catch (OperationCanceledException)
            {
                statusView.Items.Add("Cancelled ..");
            }
        }

        private Task LongRunningOperation()
        {
            return Task.Run(() =>
            {
                foreach (var i in Enumerable.Range(1, 10))
                {
                    if (TokenSource.IsCancellationRequested)
                        Token.ThrowIfCancellationRequested();

                    Thread.Sleep(1000);
                    statusView.Items.Add("Working ..");
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TokenSource.Cancel();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //TokenSource = new CancellationTokenSource(4000);
                TokenSource = new CancellationTokenSource();
                Token = TokenSource.Token;

                var person = await GetById(id: 21);
                statusView.Items.Add(person.Name);
            }
            catch (OperationCanceledException exp)
            {
                statusView.Items.Add(exp.Message);
            }
            catch (InvalidOperationException exp)
            {
                statusView.Items.Add(exp.Message);
            }
        }

        private async Task<Person> GetById(int id)
            => (await GetPersonsFromDb()).Single(x => x.Id == id);

        private Task<List<Person>> GetPersonsFromDb()
        {
            return Task.Run(() =>
            {
                var persons = new List<Person>();

                foreach (var i in Enumerable.Range(1, 5))
                {
                    if (TokenSource.IsCancellationRequested)
                        Token.ThrowIfCancellationRequested();

                    // not blocking ui thread
                    Thread.Sleep(1000);
                    statusView.Items.Add("Working ..");

                    persons.Add(new Person
                    {
                        Id = 20 + i,
                        Name = $"[{20 + i}]: x"
                    });
                }

                return persons;
            });
        }
    }
}
