﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using RestEaseClientGenerator.VSIX.Commands;
using RestEaseClientGenerator.VSIX.Commands.AddNew;
using RestEaseClientGenerator.VSIX.Commands.CustomTool;
using RestEaseClientGenerator.VSIX.Options.RestEase;
using OutputWindow = RestEaseClientGenerator.VSIX.Windows.OutputWindow;
using Task = System.Threading.Tasks.Task;

namespace RestEaseClientGenerator.VSIX
{
    [ExcludeFromCodeCoverage]
    [Guid("47AFE4E1-0000-4FE1-8CA7-EDB8310BDA4A")]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(VsixName, "", "1.0")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideUIContextRule(
        "A3381E62-0000-436F-824E-5F0097387C11",
        "UI Context",
        "json | yml | yaml | raml",
        new[] { "json", "yml", "yaml", "raml" },
        new[] { "HierSingleSelectionName:.json$", "HierSingleSelectionName:.yml$", "HierSingleSelectionName:.yaml$", "HierSingleSelectionName:.raml" })]
    //[ProvideOptionPage(
    //    typeof(GeneralOptionPage),
    //    VsixName,
    //    GeneralOptionPage.Name,
    //    0,
    //    0,
    //    true)]
    [ProvideOptionPage(
        typeof(RestEaseOptionsPage),
        VsixName,
        "Options",
        0,
        0,
        true)]

    public sealed class VsPackage : AsyncPackage
    {
        private const string VsixName = "RestEase Client Code Generator";

        private readonly ICommandInitializer[] _commands = {
            new RestEaseCodeGeneratorCustomToolSetter(),
            new NewRestEaseClientCommand()
        };

        public static AsyncPackage Instance { get; private set; }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await base.InitializeAsync(cancellationToken, progress);
            OutputWindow.Initialize(this, VsixName);
            Instance = this;

            foreach (var command in _commands)
            {
                await command.InitializeAsync(this, cancellationToken);
            }
        }
    }
}
