const snooze = ms => new Promise(resolve => setTimeout(resolve, ms));

module.exports = {
    sleepyFibonacci: async function (n) {
        await Sleepy();
        return Fib(n);
    },

};

async function Sleepy() {
    await snooze(250);
}

function Fib(n) {
  
    if (n == 1)
        return 0;
    if (n == 2)
        return 1;

    var n1 = 0, n2 = 1;
    var fib = 0;

    for (var i = 3; i <= n; i++) {
        fib = n1 + n2;
        n1 = n2;
        n2 = fib;
    }

    return fib;
}
