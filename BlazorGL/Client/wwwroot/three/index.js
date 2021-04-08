import * as THREE from '/js/three.module.js';

let scene, camera, renderer, controls;

function init() {
	let scene = new THREE.Scene();
	camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

	renderer = new THREE.WebGLRenderer();
	renderer.setSize(window.innerWidth, window.innerHeight);
	renderer.setClearColor(0xffffff, 1);
	document.body.appendChild(renderer.domElement);

	renderer.shadowMap.enabled = true;
	renderer.shadowMap.type = THREE.PCFShadowMap;

	const origin = new THREE.Vector3(0, 0, 0);
	const length = 1;

	scene.add(new THREE.ArrowHelper(new THREE.Vector3(1, 0, 0), origin, length, 0xff0000));
	scene.add(new THREE.ArrowHelper(new THREE.Vector3(0, 1, 0), origin, length, 0x00ff00));
	scene.add(new THREE.ArrowHelper(new THREE.Vector3(0, 0, 1), origin, length, 0x0000ff));

	let gridHelper = new THREE.GridHelper(100, 100);
	scene.add(gridHelper);

	const SHADOW_MAP_WIDTH = 4096, SHADOW_MAP_HEIGHT = 4096;


	let light = new THREE.SpotLight(0xffffff, 1, 0, Math.PI / 8);
	light.position.set(0, 100, 0);
	light.target.position.set(0, 0, 0);

	light.castShadow = true;
	light.shadow.camera.near = 1;
	light.shadow.camera.far = 200;
	light.shadow.bias = 0.0001;

	light.shadow.mapSize.width = SHADOW_MAP_WIDTH;
	light.shadow.mapSize.height = SHADOW_MAP_HEIGHT;

	scene.add(light);

	const ambient = new THREE.AmbientLight(0x444444);
	scene.add(ambient);




	camera.position.x = 5;
	camera.position.y = 3;
	camera.position.z = 5;

	controls = new THREE.OrbitControls(camera, renderer.domElement);

	//Create a camera made out of a cylinder

}

init();

var animate = function () {
	requestAnimationFrame(animate);
	controls.update();

	//	cube.rotation.x += 0.1;
	//cube.rotation.y += 0.1;

	renderer.render(scene, camera);
};

animate();