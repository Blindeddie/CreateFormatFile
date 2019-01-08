# CreateFormatFile

This is a little .Net app that creates a SQL BCP Non-XML Format file from a flat file (Currently only supports TAB, Pipe and Comma delimited files).

# Usage and parameters

Parameters: 

-p Path to flat file (as well as output path).
-f name of flat file to process.
-o name of output file.
-d delimeter of header row (t for TAB, p for Pipe, c for Comma).

usage:

CreateFormatFile -p c:\temp\ -f myflatfile -o myflatfile.fmt - d t (for Tab delimited file)

#License
