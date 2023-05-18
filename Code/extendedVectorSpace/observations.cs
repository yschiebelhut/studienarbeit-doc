public override void CollectObservations(VectorSensor sensor) {
    for (int i = 0; i < 12; i++) {
        sensor.AddObservation(
            normalize(controller.allServos[i].currentAngle));
    }

    var robotPosition = controller.getCenterPosition();
    sensor.AddObservation(robotPosition);

    var targetPosition = m_Target.transform.position;
    sensor.AddObservation(targetPosition);
}