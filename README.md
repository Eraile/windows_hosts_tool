# windows_hosts_tool
Windows tool to easily manage the hosts file: edit, save, apply and restore configurations without manual operations requiring administrator privileges.

Key features
- Simple graphical interface to add/edit/remove entries (IP ⇄ hostnames).
- Profiles/collections of entries to quickly switch between configurations.
- Basic validation of IP addresses and duplicate prevention.
- Safe application of changes with elevation when necessary.
- Export/import and batch processing via files (for integration/backup).

Quick install & usage
- Download the Windows release or build the Visual Studio project.
- Run the application; to write to C:\\Windows\\System32\\drivers\\etc\\hosts
- Elevation (run as administrator) is required.
- Use profiles to prepare multiple sets of entries then "Apply" to write the system hosts file.

Notes
- The tool does not modify other system files; it only works on the hosts file.
- Automatic backups: a copy of the hosts file is kept before each write.
- See the full documentation for tutorials and detailed options.

Resources
![](README_content/hosts.png)

Full documentation: https://eraile.github.io/windows_hosts_tool/