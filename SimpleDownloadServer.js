const { spawn } = require('child_process');
const dotnet = spawn('dotnet', ['run', '--urls', 'http://*:5000']);

dotnet.stdout.pipe(process.stdout);
dotnet.stderr.pipe(process.stderr);
