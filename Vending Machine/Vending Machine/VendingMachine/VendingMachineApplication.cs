﻿using System;
using System.Collections.Generic;
using RemoteLearning.VendingMachine.Exceptions;
using RemoteLearning.VendingMachine.PresentationLayer;

namespace RemoteLearning.VendingMachine
{
    internal class VendingMachineApplication
    {
        private readonly List<IUseCase> useCases;
        private readonly MainView mainView;

        public VendingMachineApplication(List<IUseCase> useCases, MainView mainView)
        {
            this.useCases = useCases ?? throw new ArgumentNullException(nameof(useCases));
            this.mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
        }

        public void Run()
        {
            mainView.DisplayApplicationHeader();

            while (true)
            {
                List<IUseCase> availableUseCases = GetExecutableUseCases();

                try
                {
                    IUseCase useCase = mainView.ChooseCommand(availableUseCases);
                    useCase.Execute();
                }
                catch (CancelException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private List<IUseCase> GetExecutableUseCases()
        {
            List<IUseCase> executableUseCases = new List<IUseCase>();

            foreach (IUseCase useCase in useCases)
            {
                if (useCase.CanExecute)
                    executableUseCases.Add(useCase);
            }

            return executableUseCases;
        }
    }
}