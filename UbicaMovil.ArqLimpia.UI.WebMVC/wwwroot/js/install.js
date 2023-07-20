'use strict';

let defferedInstallPrompt = null;
const installButton = document.getElementById('butInstall');
installButton.addEventListener('click', installPWA);

window.addEventListener('beforeinstallprompt', saveBeforeInstallPromptEvent);

function saveBeforeInstallPromptEvent(evt) {

	deferredInstallPrompt = evt;
	installButton.removeAttribute('hidden');
}

function installPWA(evt) {

	defferedInstallPrompt.prompt();
	evt.srcElement.setAttribute('hidden', true);
	defferedInstallPrompt.userChoice.then((choice) => {

		if (choice.outcome === "accepted") {

			console.log("Aceptado")

		} else {
			console.log("No aceptado")
		}

		defferedInstallPrompt = null;
	})
}

window.addEventListener('appinstalled', logAppInstalled);

function logAppInstalled(evt) {

	console.log("Ubica Móvil Instalada");
}