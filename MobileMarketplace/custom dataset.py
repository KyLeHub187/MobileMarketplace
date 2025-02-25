import glob

with open("custom_dataset.txt", "w", encoding="utf-8") as outfile:
    for filename in glob.glob("*.cs"):
        outfile.write(f"==== {filename} ====\n\n")
        with open(filename, "r", encoding="utf-8") as infile:
            outfile.write(infile.read())
        outfile.write("\n\n")