public float getReward() {
    if (isTurned()) {
        return -10.0f;
    }

    var reward = -0.0025f;
    reward += getAngle() * -0.0025f;

    var change = getProgress() - lastProg;
    lastProg = getProgress();
    return change + reward;
}

public float getAngle() {
    var up = center.forward;
    var angle = Vector3.Angle(up, Vector3.up);
    return angle % 90;
}

public bool isTurned() {
    var up = center.forward;
    var angle = Vector3.Angle(up, Vector3.up);
    return angle > 90;
}