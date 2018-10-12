const spawn = require('child_process').spawn;
const dotnet = spawn('dotnet', ['run', '--urls', 'http://*:5000'], { cwd: __dirname });

dotnet.stdout.pipe(process.stdout);
dotnet.stderr.pipe(process.stderr);
